using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using MultilingualProject.WebApp.Blogs.Dtos;

namespace MultilingualProject.WebApp.Blogs
{
    
    public interface IBlogAppService:IAsyncCrudAppService<BlogDto,Guid,PagedBLogResultRequestDto,BlogCreateDto>
    {
    }
}
