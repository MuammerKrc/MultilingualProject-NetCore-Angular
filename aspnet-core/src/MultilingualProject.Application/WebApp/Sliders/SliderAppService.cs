using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using MultilingualProject.Entities.MultilingualEntities.Sliders;
using MultilingualProject.WebApp.Sliders.Dtos;

namespace MultilingualProject.WebApp.Sliders
{
    public class SliderAppService :
        AsyncCrudAppService<Slider, SliderDto, Guid, PagedSliderResultRequestDto, CreateSliderDto>, ISliderAppService
    {
        public SliderAppService(IRepository<Slider, Guid> repository) : base(repository)
        {
        }

        public Task Sort(Guid[] Ids)
        {
            throw new NotImplementedException();
        }
    }
}