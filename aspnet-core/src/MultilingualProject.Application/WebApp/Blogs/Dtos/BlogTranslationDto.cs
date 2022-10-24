using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MultilingualProject.Entities.MultilingualEntities.Blog;

namespace MultilingualProject.WebApp.Blogs.Dtos
{
    [AutoMapTo(typeof(BlogTranslation))]
    [AutoMapFrom(typeof(BlogTranslation))]
    public class BlogTranslationDto:TranslationDtoBase
    {
        public BlogTranslationDto(){}
        public BlogTranslationDto(string lang, bool isLanguageDisabled) : base(lang, isLanguageDisabled)
        {
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }

    }
}
