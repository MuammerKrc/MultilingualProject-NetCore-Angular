using Abp.Application.Services.Dto;

namespace MultilingualProject.WebApp.TextContents.Dto
{
    public class PagedTextContentRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public string Language { get; set; }
    }
}
