using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using MultilingualProject.WebApp.Sliders.Dtos;

namespace MultilingualProject.WebApp.Sliders
{
    public  interface ISliderAppService:IAsyncCrudAppService<SliderDto,Guid,PagedSliderResultRequestDto,CreateSliderDto>
    {
        Task Sort(Guid[] Ids);
    }
}
