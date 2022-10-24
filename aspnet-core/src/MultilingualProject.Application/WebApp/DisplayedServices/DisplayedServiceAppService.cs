using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using MultilingualProject.Authorization;
using MultilingualProject.Entities.MultilingualEntities;
using MultilingualProject.Entities.MultilingualEntities.DisplayedServices;
using MultilingualProject.WebApp.DisplayedServices.Dto;
using MultilingualProject.WebApp.Urls;
using MultilingualProject.WebApp.Urls.Dto;

namespace MultilingualProject.WebApp.DisplayedServices
{
    public class DisplayedServiceAppService :
        AsyncCrudAppService<DisplayedService, DisplayedServiceDto, Guid, DisplayedServicePagedResultRequestDto,
            CreateDisplayedServiceDto>, IDisplayedServiceAppService
    {
        private const string folderPath = "Web/DisplayedService";
        private readonly IUrlsAppService _urlsAppService;
        private readonly IRepository<Url> _urlRepository;
        public const string SERVICE_DISCRIMINATOR = nameof(MultilingualProject.Entities.MultilingualEntities.DisplayedServices);

        public DisplayedServiceAppService(IRepository<DisplayedService, Guid> repository,
            IUrlsAppService urlsAppService, IRepository<Url> urlRepository) : base(repository)
        {
            _urlsAppService = urlsAppService;
            _urlRepository = urlRepository;
        }

        protected override IQueryable<DisplayedService> CreateFilteredQuery(DisplayedServicePagedResultRequestDto input)
        {
            input.Keyword = input.Keyword?.Trim();

            return base.CreateFilteredQuery(input).Include(c => c.Translations)
                .WhereIf(!input.Language.IsNullOrWhiteSpace(), c =>
                    c.Translations.Any(d => d.Language == input.Language))
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), d =>
                    d.Translations.Any(d =>
                        d.Name.Contains(input.Keyword) ||
                        d.Description.Contains(input.Keyword) ||
                        d.ShortDescription.Contains(input.Keyword)
                    )
                );
        }

        public override async Task<DisplayedServiceDto> CreateAsync(CreateDisplayedServiceDto input)
        {
            if (input.Image?.Length > 0)
                input.ImageUrl = await input.Image.SaveImageToS3("", folderPath);

            int lastItem = Repository.GetAll().OrderByDescending(c => c.OrderNo).Select(c => c.OrderNo).FirstOrDefault();
            input.OrderNo = lastItem != 0 ? lastItem + 1 : 0;
            var entity = MapToEntity(input);

            await Repository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            await _urlsAppService.GenerateDisplayedServiceUrl(entity);
            return MapToEntityDto(entity);
        }

        public override async Task<DisplayedServiceDto> UpdateAsync(CreateDisplayedServiceDto input)
        {
            if (string.IsNullOrWhiteSpace(input.ImageUrl) && input.Image?.Length > 0)
                input.ImageUrl = await input.Image.SaveImageToS3("", folderPath);

            var entity = await Repository.GetAllIncluding(p => p.Translations).FirstOrDefaultAsync(p => p.Id == input.Id);
            entity.Translations.Clear();
            ObjectMapper.Map(input, entity);
            await Repository.UpdateAsync(entity);
            await _urlsAppService.GenerateDisplayedServiceUrl(entity);
            return MapToEntityDto(entity);
        }

        public override async Task<DisplayedServiceDto> GetAsync(EntityDto<Guid> input)
        {
            var service = await Repository.Query(c => c.Include(d => d.Translations).Where(d => d.Id == input.Id))
                .FirstOrDefaultAsync();
            return ObjectMapper.Map<DisplayedServiceDto>(service);
        }

        protected override IQueryable<DisplayedService> ApplySorting(IQueryable<DisplayedService> query,
            DisplayedServicePagedResultRequestDto input)
        {
            return query.OrderByDescending(r => r.OrderNo);
        }

        public async Task Sort(Guid[] Ids)
        {
            var list = await Repository.GetAll().Where(i => Ids.Any(j => j.Equals(i.Id)))
                .OrderByDescending(c => c.OrderNo)
                .ToListAsync();
            var sortList = list.Select(c => c.OrderNo).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                list.FirstOrDefault(d => d.Id == Ids[i]).OrderNo = sortList[i];
            }
        }

        public override async Task DeleteAsync(EntityDto<Guid> input)
        {
            await _urlRepository.DeleteAsync(d => d.ItemPkId == input.Id && d.Discriminator == SERVICE_DISCRIMINATOR);
            await Repository.DeleteAsync(d => d.Id == input.Id);
        }
    }
}