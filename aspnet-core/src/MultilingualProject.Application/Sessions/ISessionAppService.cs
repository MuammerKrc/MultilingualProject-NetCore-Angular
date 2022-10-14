using System.Threading.Tasks;
using Abp.Application.Services;
using MultilingualProject.Sessions.Dto;

namespace MultilingualProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
