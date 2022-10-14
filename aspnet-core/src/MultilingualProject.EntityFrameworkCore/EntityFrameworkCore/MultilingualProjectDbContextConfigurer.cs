using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MultilingualProject.EntityFrameworkCore
{
    public static class MultilingualProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MultilingualProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MultilingualProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
