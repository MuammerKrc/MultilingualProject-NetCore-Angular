using AutoMapper;
using MultilingualProject.Entities.MultilingualEntities.DisplayedServices;

namespace MultilingualProject.WebApp.DisplayedServices.Dto

{
    public class DisplayedServiceMapProfile : Profile
    {
        public DisplayedServiceMapProfile()
        {
            CreateMap<DisplayedService, DisplayedServiceDto>().ReverseMap();
            CreateMap<DisplayedServiceTranslation, DisplayedServiceTranslationDto>().ReverseMap();
            CreateMap<CreateDisplayedServiceDto , DisplayedService>().ReverseMap();
            CreateMap<CreateDisplayedServiceDto , DisplayedServiceDto>();
        }
    }
}
