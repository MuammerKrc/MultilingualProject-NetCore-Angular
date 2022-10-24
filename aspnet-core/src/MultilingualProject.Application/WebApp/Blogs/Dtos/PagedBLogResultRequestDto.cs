using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace MultilingualProject.WebApp.Blogs.Dtos
{
    public class PagedBLogResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public string Language { get; set; }
    }
}
