﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Waffenschmidt.MultiTenancy.Persistence.SchemaSeparation;

namespace Waffenschmidt.MultiTenancy.Persistence.SchemaSeparation.Extensions
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