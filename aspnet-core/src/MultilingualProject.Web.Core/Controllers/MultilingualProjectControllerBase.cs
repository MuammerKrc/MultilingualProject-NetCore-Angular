using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MultilingualProject.Controllers
{
    public abstract class MultilingualProjectControllerBase: AbpController
    {
        protected MultilingualProjectControllerBase()
        {
            LocalizationSourceName = MultilingualProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
