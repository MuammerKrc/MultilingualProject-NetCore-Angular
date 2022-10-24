using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using MultilingualProject.Entities.MultilingualEntities.FAQs;
using MultilingualProject.Enums;

namespace MultilingualProject.WebApp.FAQs.Dtos
{
    [AutoMapTo(typeof(FaqDto))]
    [AutoMapFrom(typeof(FaqTranslation))]
    public class FaqDto:EntityDto<int>,IML<FaqTranslationDto>
    {
        public int OrderNo { get; set; }
        public FaqCategoryType FaqCategoryType { get; set; }
        public List<FaqTranslationDto> Translations { get; set; }
    }
}
