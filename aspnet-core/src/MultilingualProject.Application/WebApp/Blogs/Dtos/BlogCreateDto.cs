using Abp.AutoMapper;
using MultilingualProject.Entities.MultilingualEntities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace MultilingualProject.WebApp.Blogs.Dtos
{
    [AutoMapTo(typeof(Blog))]
    [AutoMapFrom(typeof(Blog))]
    public class BlogCreateDto : EntityDto<Guid>, IML<BlogTranslationDto>
    {
        public byte[] Image { get; set; }
        public string CoverImagePath { get; set; }
        public List<BlogTranslationDto> Translations { get; set; }
    }
}
