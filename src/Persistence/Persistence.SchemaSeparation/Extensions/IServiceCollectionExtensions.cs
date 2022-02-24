using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Florez4Code.MultiTenancy.Persistence.SchemaSeparation.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSchemaServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IModelCacheKeyFactory, SchemaCacheKeyFactory>();
            serviceCollection.AddSingleton<IMigrationsAssembly, SchemaMigrationAssembly>();
            return serviceCollection;
        }
    }
}