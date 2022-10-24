using AutoMapper;
using MultilingualProject.Entities.MultilingualEntities.TextContents;

namespace MultilingualProject.WebApp.TextContents.Dto
{
    public class TextContentMapProfile : Profile
    {
        public TextContentMapProfile()
        {
            CreateMap<TextContent, TextContentDto>().ReverseMap();
            CreateMap<TextContentTranslation, TextContentTranslationDto>().ReverseMap();
        }
    }
}
