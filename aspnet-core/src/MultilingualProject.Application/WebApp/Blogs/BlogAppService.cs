using Abp.Application.Services;
using MultilingualProject.Entities.MultilingualEntities.Blog;
using MultilingualProject.WebApp.Blogs.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace MultilingualProject.WebApp.Blogs
{
    public class BlogAppService : AsyncCrudAppService<Blog, BlogDto, Guid, PagedBLogResultRequestDto, BlogCreateDto>, IBlogAppService
    {
        public BlogAppService(IRepository<Blog, Guid> repository) : base(repository)
        {
        }
    }
}
