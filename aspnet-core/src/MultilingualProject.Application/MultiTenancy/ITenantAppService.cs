using Abp.Application.Services;
using MultilingualProject.MultiTenancy.Dto;

namespace MultilingualProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

