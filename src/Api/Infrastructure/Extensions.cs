using Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddContext(this IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();

                services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x =>
                {
                    x.MigrationsAssembly(typeof(Identifier).Namespace);
                    x.MigrationsHistoryTable("EFMigrationsHistory", "public");
                }));
            }

            return services;
        }

        
    }
}
