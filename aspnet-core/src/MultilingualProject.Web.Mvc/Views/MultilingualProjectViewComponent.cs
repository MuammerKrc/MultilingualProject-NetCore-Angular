using Abp.AspNetCore.Mvc.ViewComponents;

namespace MultilingualProject.Web.Views
{
    public abstract class MultilingualProjectViewComponent : AbpViewComponent
    {
        protected MultilingualProjectViewComponent()
        {
            LocalizationSourceName = MultilingualProjectConsts.LocalizationSourceName;
        }
    }
}
