using Abp.AutoMapper;

namespace MultilingualProject.WebApp.DisplayedServices.Dto

{
    public class DisplayedServiceTranslationDto : TranslationDtoBase
    {
        public DisplayedServiceTranslationDto() { }
        public DisplayedServiceTranslationDto(string lang, bool isLanguageDisabled) : base(lang, isLanguageDisabled) { }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}
