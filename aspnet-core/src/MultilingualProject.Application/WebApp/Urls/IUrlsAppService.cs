using Abp.Application.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultilingualProject.Entities.MultilingualEntities.Blog;
using MultilingualProject.Entities.MultilingualEntities.TextContents;
using MultilingualProject.WebApp.Urls.Dto;

namespace MultilingualProject.WebApp.Urls.Dto
{
    public interface IUrlsAppService : IApplicationService
    {
        Task<List<UrlDto>> GetAllUrls();
        //Task GenerateDisplayedServiceUrl(DisplayedService service);
        Task GenerateBlogUrl(Blog blog);
        Task GenerateTextContentUrl(TextContent textContent);
        Task DeleteUrlsOf(Guid primaryKey, string discriminator);
        Task ClearRouteUrlCache();
    }
}