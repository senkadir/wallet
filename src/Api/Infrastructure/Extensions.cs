using Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure
{
    public static class Extensions
    {
        internal static IServiceCollection AddContext(this IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();

                services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x =>
                {
                    x.MigrationsAssembly(typeof(DataIdentifier).Namespace);
                    x.MigrationsHistoryTable("EFMigrationsHistory");
                }));
            }

            return services;
        }

        internal static void InitializeDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var environment = serviceScope.ServiceProvider.GetService<IHostEnvironment>();

            if (environment == null)
            {
                return;
            }

            if (environment.EnvironmentName == "Docker")
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                if (db == null)
                {
                    return;
                }

                db.Database.Migrate();
            }
        }
    }
}
