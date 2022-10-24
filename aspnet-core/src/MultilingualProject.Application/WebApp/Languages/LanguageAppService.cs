using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Localization;
using Microsoft.EntityFrameworkCore;
using MultilingualProject.Entities.MultilingualEntities;
using MultilingualProject.WebApp.Languages.Dtos;

namespace MultilingualProject.WebApp.Languages
{
    public class LanguageAppService : AsyncCrudAppService<ApplicationLanguage, LanguageDto, int, PagedBaseResultRequestDto>,ILanguageAppService
    {

        private readonly IRepository<WebLanguage> _webLanguageRepository;

        public LanguageAppService(IRepository<ApplicationLanguage, int> repository,
            IRepository<WebLanguage> webLanguageRepository) : base(repository)
        {
            _webLanguageRepository = webLanguageRepository;
        }


        public override async Task<PagedResultDto<LanguageDto>> GetAllAsync(PagedBaseResultRequestDto input)
        {
            var langs = await base.GetAllAsync(input);
            var webActive = await _webLanguageRepository.GetAll().ToListAsync();
            foreach (var languageDto in langs.Items)
            {
                languageDto.IsActiveOnWeb = webActive.Any(c => c.LanguageId == languageDto.Id);
            }

            return langs;
        }

        public override async Task<LanguageDto> GetAsync(EntityDto<int> input)
        {
            var lang = await base.GetAsync(input);
            var webActive = await _webLanguageRepository.GetAll().ToListAsync();
            lang.IsActiveOnWeb = webActive.Any(c => c.LanguageId == lang.Id);
            return lang;
        }

        protected override IQueryable<ApplicationLanguage> CreateFilteredQuery(PagedBaseResultRequestDto input)
        {
            input.Keyword = input.Keyword?.Trim();

            return base.CreateFilteredQuery(input)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), c =>
                    c.Name.Contains(input.Keyword) || c.DisplayName.Contains(input.Keyword));
        }

        public override async Task<LanguageDto> CreateAsync(LanguageDto input)
        {
            input.DisplayName = input.DisplayName?.Trim();

            var result = await base.CreateAsync(input);

            if (input.IsActiveOnWeb)
                await _webLanguageRepository.InsertAsync(new WebLanguage()
                {
                    LanguageId = result.Id
                });
            return result;
        }

        public override async Task<LanguageDto> UpdateAsync(LanguageDto input)
        {
            input.DisplayName = input.DisplayName?.Trim();

            if (input.IsActiveOnWeb)
            {
                var count = await _webLanguageRepository.CountAsync(c => c.LanguageId == input.Id);
                if (count == 0)
                    await _webLanguageRepository.InsertOrUpdateAsync(new WebLanguage()
                    {
                        LanguageId = input.Id
                    });
            }
            else
            {
                await _webLanguageRepository.DeleteAsync(c => c.LanguageId == input.Id);
            }

            return await base.UpdateAsync(input);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            await _webLanguageRepository.DeleteAsync(c => c.LanguageId == input.Id);
            await base.DeleteAsync(input);
        }
    }

}
