using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MultilingualProject.Entities.MultilingualEntities.DisplayedServices;

namespace MultilingualProject.WebApp.DisplayedServices.Dto

{

    [AutoMapFrom(typeof(DisplayedService))]
    public class DisplayedServiceDto : EntityDto<Guid>, IML<DisplayedServiceTranslationDto>
    {
        public int OrderNo { get; set; }
        public string ImageUrl { get; set; }
        public List<DisplayedServiceTranslationDto> Translations { get; set; }
    }
}
