using AutoMapper;
using MultilingualProject.Entities.MultilingualEntities.Sliders;

namespace MultilingualProject.WebApp.Sliders.Dtos

{
    public class SliderMapProfile : Profile
    {
        public SliderMapProfile()
        {
            CreateMap<Slider, SliderDto>().ReverseMap();
        }
    }
}
