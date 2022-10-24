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
    [AutoMapTo(typeof(Blog))]
    [AutoMapFrom(typeof(Blog))]
    public class BlogDto:EntityDto<Guid>,IML<BlogTranslationDto>
    {
        public string CoverImagePath { get; set; }
        public List<BlogTranslationDto> Translations { get; set; }
    }
}
