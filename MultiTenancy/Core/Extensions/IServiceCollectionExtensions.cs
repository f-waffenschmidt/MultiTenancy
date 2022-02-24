using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MultiTenancy.Abstraction;
using MultiTenancy.Core.Resolver;

namespace MultiTenancy.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMultiTenancyOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<MultiTenancyOptions>(configuration.GetSection(MultiTenancyConstants.ConfigurationSection));
            serviceCollection.AddTransient(provider =>
            {
                var options = provider.GetRequiredService<IOptions<MultiTenancyOptions>>();
                return options.Value;
            });
            return serviceCollection;
        }
    }
}