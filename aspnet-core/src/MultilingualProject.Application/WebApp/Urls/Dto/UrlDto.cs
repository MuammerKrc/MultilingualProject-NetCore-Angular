using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MultilingualProject.Entities.MultilingualEntities;

namespace MultilingualProject.WebApp.Urls.Dto
{
    [AutoMapFrom(typeof(Url))]
    public class UrlDto: FullAuditedEntityDto
    {
        public string Value { get; set; }
        public string Parameters { get; set; }
        public string RedirectUrl { get; set; }
        public Guid? ItemPkId { get; set; }
        public string Language { get; set; }
        public string Discriminator { get; set; }
    }
}