using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MultilingualProject.Authorization.Roles;
using MultilingualProject.Authorization.Users;
using MultilingualProject.MultiTenancy;

namespace MultilingualProject.EntityFrameworkCore
{
    public class MultilingualProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MultilingualProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MultilingualProjectDbContext(DbContextOptions<MultilingualProjectDbContext> options)
            : base(options)
        {
        }
    }
}
