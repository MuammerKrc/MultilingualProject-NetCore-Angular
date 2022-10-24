using Abp.Application.Services.Dto;

namespace MultilingualProject.WebApp.Sliders.Dtos

{
    public class PagedSliderResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public string Language { get; set; }
    }
}
