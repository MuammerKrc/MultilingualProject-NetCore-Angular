using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultilingualProject.Configuration;

namespace MultilingualProject.Web.Host.Startup
{
    [DependsOn(
       typeof(MultilingualProjectWebCoreModule))]
    public class MultilingualProjectWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MultilingualProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultilingualProjectWebHostModule).GetAssembly());
        }
    }
}
