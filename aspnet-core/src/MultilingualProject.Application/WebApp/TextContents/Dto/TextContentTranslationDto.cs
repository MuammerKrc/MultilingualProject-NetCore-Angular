using Abp.AutoMapper;
using MultilingualProject.Entities.MultilingualEntities.TextContents;

namespace MultilingualProject.WebApp.TextContents.Dto
{
    [AutoMapFrom(typeof(TextContentTranslation))]
    public class TextContentTranslationDto : TranslationDtoBase
    {
        public TextContentTranslationDto() { }
        public TextContentTranslationDto(string lang, bool isLanguageDisabled) : base(lang, isLanguageDisabled) { }


        public string Title { get; set; }
        public string Description { get; set; }
        
        public string MenuTitle { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Url { get; set; }
    }
}
