using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using MultilingualProject.Entities.MultilingualEntities.Sliders;

namespace MultilingualProject.WebApp.Sliders.Dtos
{
    [AutoMapTo(typeof(Slider))]
    [AutoMapFrom(typeof(Slider))]
    public class SliderDto : EntityDto<Guid>, IML<SliderTranslationDto>
    {
        public string ImagePath { get; set; }
        public bool IsVisible360Car { get; set; }
        public int OrderNo { get; set; }
        public List<SliderTranslationDto> Translations { get; set; }
    }
}