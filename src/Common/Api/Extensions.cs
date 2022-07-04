using Common.Core;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Common.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, Type implementationType)
        {
            services.AddTransient<IServiceBase, ServiceBase>();

            services.Scan(scan =>
                scan.FromAssembliesOf(implementationType)
                    .AddClasses(x => x.AssignableTo<IServiceBase>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            return services;
        }
    }
}
