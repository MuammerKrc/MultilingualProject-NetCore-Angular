using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Localization;
using Abp.Runtime.Caching;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Linq.Extensions;

using MultilingualProject.Authorization;
using MultilingualProject.Entities.MultilingualEntities;
using MultilingualProject.Entities.MultilingualEntities.Blog;
using MultilingualProject.Entities.MultilingualEntities.DisplayedServices;
using MultilingualProject.Entities.MultilingualEntities.TextContents;
using MultilingualProject.Extensions;
using MultilingualProject.WebApp.DisplayedServices;
using MultilingualProject.WebApp.Urls.Dto;

namespace MultilingualProject.WebApp.Urls
{
    [UnitOfWork]
    public class UrlsAppService : ApplicationService, IUrlsAppService
    {
        private readonly string[] _activeLanguages;
        private readonly string[] _allLanguages;

        private readonly IRepository<Url> _urlRepository;
        private readonly IRepository<TextContent, Guid> _textContentRepository;
        private readonly IRepository<Blog, Guid> _blogRepository;
        private readonly IRepository<DisplayedService, Guid> _displayedServiceRepository;

        private readonly ICacheManager _cacheManager;
        public static readonly string SERVICE_DISCRIMINATOR = "DisplayedService";
        public static readonly string BLOG_DISCRIMINATOR = "Blog";
        public static readonly string TEXTCONTENT_DISCRIMINATOR = "TextContent";

        public UrlsAppService(ILanguageManager languageManager,
            IRepository<Url> urlRepository,
            IRepository<TextContent, Guid> textContentRepository,
            IRepository<Blog, Guid> blogRepository,
            IRepository<DisplayedService, Guid> displayedServiceRepository,
            ICacheManager cahceManager)
        {
            _activeLanguages = languageManager.GetActiveLanguages().Select(l => l.Name).ToArray();
            _allLanguages = languageManager.GetLanguages().Select(l => l.Name).ToArray();
            _urlRepository = urlRepository;
            _textContentRepository = textContentRepository;
            _blogRepository = blogRepository;
            _displayedServiceRepository = displayedServiceRepository;
            _cacheManager = cahceManager;
            LocalizationSourceName = "EndesErp";
        }

        public async Task GenerateDisplayedServiceUrl(DisplayedService service)
        {
            if (service != null && service.Translations != null)
            {
                foreach (var lang in _allLanguages)
                {
                    var formattedUrl = service.Translations.FirstOrDefault(l => l.Language == lang)?.Name
                        ?.ToSeoFriendly();
                    if (formattedUrl.IsNullOrWhiteSpace()) continue;
                    var urlPrefix = L("DisplayedServiceUrlPrefix", CultureInfo.GetCultureInfo(lang));

                    var url = $"{urlPrefix}/{formattedUrl}";
                    var parameters = new Dictionary<string, string>
                    {
                        {"controller", "Service"},
                        {"action", "Detail"},
                        {"id", service.Id.ToString()},
                        {"lang", lang}
                    };
                    await CreateOrUpdateUrl(url, lang, parameters, service.Id, SERVICE_DISCRIMINATOR);
                }
            }
        }

        public async Task GenerateBlogUrl(Blog blog)
        {
            if (blog != null && blog.Translations != null)
            {
                foreach (var lang in _allLanguages)
                {
                    var formattedUrl = blog.Translations.FirstOrDefault(l => l.Language == lang)?.Title
                        ?.ToSeoFriendly();
                    if (formattedUrl.IsNullOrWhiteSpace()) continue;
                    var urlPrefix = L("BlogUrlPrefix", CultureInfo.GetCultureInfo(lang));

                    var url = $"{urlPrefix}/{formattedUrl}";
                    var parameters = new Dictionary<string, string>
                    {
                        {"controller", "Blog"},
                        {"action", "Detail"},
                        {"id", blog.Id.ToString()},
                        {"lang", lang}
                    };
                    await CreateOrUpdateUrl(url, lang, parameters, blog.Id, BLOG_DISCRIMINATOR);
                }
            }
        }

        public async Task GenerateTextContentUrl(TextContent textContent)
        {
            if (textContent != null && textContent.Translations != null)
            {
                foreach (var lang in _allLanguages)
                {
                    var formattedUrl = textContent.Translations.FirstOrDefault(l => l.Language == lang)?.Title
                        ?.ToSeoFriendly();
                    if (formattedUrl.IsNullOrWhiteSpace()) continue;
                    var urlPrefix = L("TextContentUrlPrefix", CultureInfo.GetCultureInfo(lang));

                    var url = $"{urlPrefix}/{formattedUrl}";
                    var parameters = new Dictionary<string, string>
                    {
                        {"controller", "TextContent"},
                        {"action", "Detail"},
                        {"id", textContent.Id.ToString()},
                        {"lang", lang}
                    };
                    var result = await CreateOrUpdateUrl(url, lang, parameters, textContent.Id,
                        TEXTCONTENT_DISCRIMINATOR);

                    foreach (var item in textContent.Translations)
                    {
                        if (item.Language == result.lang)
                            item.Url = result.url;
                    }
                }

                await _textContentRepository.UpdateAsync(textContent);
            }
        }

        public async Task ClearRouteUrlCache()
        {
            var keyFormat = "allUrls";
            await _cacheManager.GetCache(keyFormat).ClearAsync();
        }

        [AbpAllowAnonymous]
        public async Task<List<UrlDto>> GetAllUrls()
        {
            var urls = await _urlRepository.GetAll().Where(a => _activeLanguages.Any(c => c == a.Language))
                .AsNoTracking()
                .ToListAsync();
            return ObjectMapper.Map<List<UrlDto>>(urls);
        }

        public async Task DeleteUrlsOf(Guid primaryKey, string discriminator) =>
            await _urlRepository.DeleteAsync(f => f.ItemPkId == primaryKey && f.Discriminator == discriminator);

        /// <summary>
        /// Bu metod çalıştırıldığında tüm urller silinir ( metoddaki parametreye bağlı olarak istisna vardır ) ve yeniden yazılır.
        /// </summary>
        /// <param name="isDeleteHasRedirectUrlRow">bu parametre true olduğunda redirect url değerine sahip olan veriler silinmez false olduğunda silinir </param>
        /// <returns></returns>
        public async Task ClearAllUrlsAndGenerate(bool isDeleteHasRedirectUrlRow = false)
        {
            var urls = await _urlRepository.GetAll().ToListAsync();
            if (!isDeleteHasRedirectUrlRow)
            {
                urls = urls.Where(c => c.RedirectUrl.IsNullOrWhiteSpace()).ToList();
            }

            foreach (var item in urls)
            {
                await _urlRepository.DeleteAsync(item);
            }

            await CurrentUnitOfWork.SaveChangesAsync();

            var textContents = await _textContentRepository.GetAll().Include(d => d.Translations).Where(d => string.IsNullOrEmpty(d.Key)).ToListAsync();
            var blogs = await _blogRepository.GetAll().Include(d => d.Translations).ToListAsync();
            var displayedServices = await _displayedServiceRepository.GetAll().Include(d => d.Translations).ToListAsync();

            foreach (var item in textContents)
            {
                await GenerateTextContentUrl(item);
            }

            foreach (var item in blogs)
            {
                await GenerateBlogUrl(item);
            }

            foreach (var item in displayedServices)
            {
                await GenerateDisplayedServiceUrl(item);
            }

        }


        private async Task<(string lang, string url)> CreateOrUpdateUrl(string urlPath, string lang,
            Dictionary<string, string> parameters,
            Guid itemFkId, string disc)
        {
            var itemIdIsExists =
                await _urlRepository.FirstOrDefaultAsync(a =>
                    a.ItemPkId == itemFkId && a.Language == lang && a.Discriminator == disc);


            if (itemIdIsExists != null)
            {
                //Update
                if (itemIdIsExists.Value != urlPath)
                {
                    var param = JsonConvert.DeserializeObject<Dictionary<string, string>>(itemIdIsExists.Parameters);
                    if (param.DictionaryEqual(parameters))
                    {
                        itemIdIsExists.RedirectUrl = urlPath;
                        await _urlRepository.UpdateAsync(itemIdIsExists);
                    }
                }
                else
                {
                    return (lang, urlPath);
                }
            }

            //Insert
            Url urlItem = await _urlRepository.FirstOrDefaultAsync(c => c.Value == urlPath && c.ItemPkId != itemFkId);
            if (urlItem != null)
            {
                var splittedUrl = urlPath.Split("-");
                if (!int.TryParse(splittedUrl.LastOrDefault(), out var number))
                {
                    urlPath = $"{string.Join("-", splittedUrl)}-1";
                }
                else
                {
                    splittedUrl = splittedUrl.Take(splittedUrl.Length - 1).ToArray();
                    number++;
                    urlPath = $"{string.Join("-", splittedUrl)}-{number}";
                }

                var checkUrls = await _urlRepository.FirstOrDefaultAsync(a => a.Value == urlPath);
                while (checkUrls != null)
                {
                    number++;
                    urlPath = $"{string.Join("-", splittedUrl)}-{number}";
                    checkUrls = await _urlRepository.FirstOrDefaultAsync(a => a.Value == urlPath);
                }
            }

            await _urlRepository.InsertAsync(new Url
            {
                Parameters = JsonConvert.SerializeObject(parameters),
                Value = urlPath,
                Language = lang,
                ItemPkId = itemFkId,
                Discriminator = disc
            });
            return (lang, urlPath);
        }
    }
}