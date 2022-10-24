using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using MultilingualProject.Authorization;
using MultilingualProject.Entities.MultilingualEntities;
using MultilingualProject.Entities.MultilingualEntities.TextContents;
using MultilingualProject.WebApp.TextContents.Dto;
using MultilingualProject.WebApp.Urls.Dto;

namespace MultilingualProject.WebApp.TextContents
{
    [UnitOfWork]
    public class TextContentAppService :
        AsyncCrudAppService<TextContent, TextContentDto, Guid, PagedTextContentRequestDto>, ITextContentAppService
    {

        private readonly IUrlsAppService _urlAppService;
        private readonly IRepository<Url> _urlRepository;
        public const string TEXTCONTENT_DISCRIMINATOR = nameof(MultilingualProject.Entities.MultilingualEntities.TextContents);

        public TextContentAppService(IRepository<TextContent, Guid> repository, IUrlsAppService urlAppService, IRepository<Url> urlRepository) :
            base(repository)
        {
            _urlAppService = urlAppService;
            _urlRepository = urlRepository;
        }

        protected override IQueryable<TextContent> CreateFilteredQuery(PagedTextContentRequestDto input)
        {
            input.Keyword = input.Keyword?.Trim();

            return base.CreateFilteredQuery(input).Include(c => c.Translations)
                .WhereIf(!input.Language.IsNullOrWhiteSpace(), d => d.Translations
                    .Any(c => c.Language == input.Language))
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), d =>
                    d.Key.Contains(input.Keyword) ||
                    d.Translations.Any(c => c.Title.Contains(input.Keyword) ||
                                            c.Description.Contains(input.Keyword) ||
                                            c.MenuTitle.Contains(input.Keyword) ||
                                            c.MetaTitle.Contains(input.Keyword) ||
                                            c.MetaKeywords.Contains(input.Keyword) ||
                                            c.MetaDescription.Contains(input.Keyword)
                    ));
        }

        public override async Task<TextContentDto> CreateAsync(TextContentDto input)
        {
            var entity = MapToEntity(input);
            await Repository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            if (input.Key.IsNullOrWhiteSpace())
            {
                await _urlAppService.GenerateTextContentUrl(entity);
            }
            return MapToEntityDto(entity);
        }

        public override async Task<TextContentDto> UpdateAsync(TextContentDto input)
        {
            var textContent = await Repository.GetAllIncluding(p => p.Translations).FirstOrDefaultAsync(p => p.Id == input.Id);

            textContent.Translations.Clear();

            ObjectMapper.Map(input, textContent);

            await Repository.UpdateAsync(textContent);

            if (input.Key.IsNullOrWhiteSpace())
                await _urlAppService.GenerateTextContentUrl(textContent);

            return MapToEntityDto(textContent);
        }

        //public override async Task DeleteAsync(EntityDto<Guid> input)
        //{
        //    await _urlRepository.DeleteAsync(d => d.ItemPkId == input.Id && d.Discriminator == TEXTCONTENT_DISCRIMINATOR);
        //    await Repository.DeleteAsync(d => d.Id == input.Id);
        //}

        public override async Task<TextContentDto> GetAsync(EntityDto<Guid> input)
        {
            var textContent = await Repository.GetAll().Include(c => c.Translations)
                .FirstOrDefaultAsync(c => c.Id == input.Id);

            return ObjectMapper.Map<TextContentDto>(textContent);
        }
    }
}