using System.Threading.Tasks;
using MultilingualProject.Configuration.Dto;

namespace MultilingualProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
