using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using MultilingualProject.WebApp.MLObjects.Dtos;

namespace MultilingualProject.WebApp.MLObjects
{
    public interface IMLObjectsAppService:IAsyncCrudAppService<MLObjectsDto,int,PagedBaseResultRequestDto>
    {
        Task<List<MLObjectsDto>> GetObjectContainer(string containerKey, string culture = null);

    }
}
