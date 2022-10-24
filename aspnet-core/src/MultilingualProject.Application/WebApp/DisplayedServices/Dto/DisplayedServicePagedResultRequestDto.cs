using Abp.Application.Services.Dto;

namespace MultilingualProject.WebApp.DisplayedServices.Dto

{
    public class DisplayedServicePagedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public string Language { get; set; }
    }
}
