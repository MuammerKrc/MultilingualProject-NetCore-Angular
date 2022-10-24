using Abp.AutoMapper;
using MultilingualProject.Entities.MultilingualEntities.FAQs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilingualProject.WebApp.FAQs.Dtos
{
    [AutoMapTo(typeof(FaqTranslation))]
    [AutoMapFrom(typeof(FaqTranslation))]
    public class FaqTranslationDto:TranslationDtoBase
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
