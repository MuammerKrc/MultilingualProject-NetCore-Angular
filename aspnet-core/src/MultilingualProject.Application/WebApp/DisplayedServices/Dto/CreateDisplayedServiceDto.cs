using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace MultilingualProject.WebApp.DisplayedServices.Dto
{
    public class CreateDisplayedServiceDto : EntityDto<Guid>, IML<DisplayedServiceTranslationDto>
    {
        public byte[] Image { get; set; }
        public int OrderNo { get; set; }
        public string ImageUrl { get; set; }
        public List<DisplayedServiceTranslationDto> Translations { get; set; }
    }
}
