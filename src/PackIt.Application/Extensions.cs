using Microsoft.Extensions.DependencyInjection;
using PackIt.Domain.Factories;
using PackIt.Domain.Policies;
using PackIt.Shared;

namespace PackIt.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<IPackingListFactory, PackingListFactory>();

            services.Scan(s => s.FromAssemblies(typeof(IPackingListFactory).Assembly)
                .AddClasses(c => c.AssignableTo(typeof(IPackingItemsPolicy)))
                .AsImplementedInterfaces()
                .WithSingletonLifetime()); // Because I hardcode policies, I can use singleton lifetime

            return services;
        }
    }
}
