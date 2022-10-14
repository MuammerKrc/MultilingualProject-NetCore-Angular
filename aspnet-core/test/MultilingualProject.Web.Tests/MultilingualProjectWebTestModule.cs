using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultilingualProject.EntityFrameworkCore;
using MultilingualProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MultilingualProject.Web.Tests
{
    [DependsOn(
        typeof(MultilingualProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MultilingualProjectWebTestModule : AbpModule
    {
        public MultilingualProjectWebTestModule(MultilingualProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultilingualProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MultilingualProjectWebMvcModule).Assembly);
        }
    }
}