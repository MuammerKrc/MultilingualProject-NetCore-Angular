using Abp.AutoMapper;
using MultilingualProject.Entities.MultilingualEntities.Sliders;


namespace MultilingualProject.WebApp.Sliders.Dtos

{
    [AutoMapTo(typeof(SliderTranslation))]
    [AutoMapFrom(typeof(SliderTranslation))]
    public class SliderTranslationDto : TranslationDtoBase
    {
        public SliderTranslationDto() { }
        public SliderTranslationDto(string lang, bool isLanguageDisabled) : base(lang, isLanguageDisabled) { }

        public string Title { get; set; }
        public string CallToActionButton { get; set; }
        public string CallToActionUrl { get; set; }
    }
}