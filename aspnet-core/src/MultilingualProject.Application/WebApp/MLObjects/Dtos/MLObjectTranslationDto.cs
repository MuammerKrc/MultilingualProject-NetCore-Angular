using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilingualProject.WebApp.MLObjects.Dtos
{

    public class MLObjectTranslationDto:TranslationDtoBase
    {
        public MLObjectTranslationDto() : base() { }
        public MLObjectTranslationDto(string lang, bool isLanguageDisabled) : base(lang, isLanguageDisabled) { }
        public string Value { get; set; }
    }
}
