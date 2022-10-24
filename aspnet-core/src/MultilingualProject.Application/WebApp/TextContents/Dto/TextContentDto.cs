using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.Net.Http.Headers;
using MultilingualProject.Entities.MultilingualEntities.TextContents;

namespace MultilingualProject.WebApp.TextContents.Dto
{
    [AutoMapTo(typeof(TextContent))]
    [AutoMapFrom(typeof(TextContent))]
    public class TextContentDto : EntityDto<Guid>, IML<TextContentTranslationDto>
    {
        public string Key { get; set; }

        public List<TextContentTranslationDto> Translations { get; set; }
    }
}
