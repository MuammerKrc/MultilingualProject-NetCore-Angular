using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultilingualProject.Configuration;

namespace MultilingualProject.Web.Startup
{
    [DependsOn(typeof(MultilingualProjectWebCoreModule))]
    public class MultilingualProjectWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MultilingualProjectWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<MultilingualProjectNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultilingualProjectWebMvcModule).GetAssembly());
        }
    }
}
