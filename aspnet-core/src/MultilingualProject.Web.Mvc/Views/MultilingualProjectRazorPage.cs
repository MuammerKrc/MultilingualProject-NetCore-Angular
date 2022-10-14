using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace MultilingualProject.Web.Views
{
    public abstract class MultilingualProjectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MultilingualProjectRazorPage()
        {
            LocalizationSourceName = MultilingualProjectConsts.LocalizationSourceName;
        }
    }
}
