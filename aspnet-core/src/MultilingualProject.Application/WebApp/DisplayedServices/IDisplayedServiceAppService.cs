using Abp.Application.Services;
using System;
using MultilingualProject.WebApp.DisplayedServices.Dto;

namespace MultilingualProject.WebApp.DisplayedServices

{
    public interface IDisplayedServiceAppService : IAsyncCrudAppService<DisplayedServiceDto, Guid, DisplayedServicePagedResultRequestDto, CreateDisplayedServiceDto>
    {
    }
}
