using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using MultilingualProject.Entities.MultilingualEntities.MLObjects;
using MultilingualProject.WebApp.MLObjects.Dtos;

namespace MultilingualProject.WebApp.MLObjects
{
    public class MLObjectsAppService:AsyncCrudAppService<MLObject,MLObjectsDto,int,PagedBaseResultRequestDto>,IMLObjectsAppService
    {
        public MLObjectsAppService(IRepository<MLObject, int> repository) : base(repository)
        {
        }

        public Task<List<MLObjectsDto>> GetObjectContainer(string containerKey, string culture = null)
        {
            throw new NotImplementedException();
        }
    }
}
