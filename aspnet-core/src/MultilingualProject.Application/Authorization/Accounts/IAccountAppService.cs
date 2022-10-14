using System.Threading.Tasks;
using Abp.Application.Services;
using MultilingualProject.Authorization.Accounts.Dto;

namespace MultilingualProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
