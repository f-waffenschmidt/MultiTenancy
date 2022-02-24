using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Pistolsmith.MultiTenancy.Abstraction;
using Pistolsmith.MultiTenancy.Persistence.Abstractions;

namespace Pistolsmith.MultiTenancy.Persistence.SchemaSeparation
{
    public class MultiTenantSchemaDbContext<TBuilder, TExtension> : DbContext, ISchemeDbContext
        where TBuilder : RelationalDbContextOptionsBuilder<TBuilder, TExtension>
        where TExtension : RelationalOptionsExtension, new()
    {
        private readonly ITenantAccessor _tenantAccessor;
        private readonly IConnectionProvider<TBuilder, TExtension> _connectionProvider;

        public MultiTenantSchemaDbContext(ITenantAccessor tenantAccessor, IConnectionProvider<TBuilder, TExtension> connectionProvider,
            DbContextOptions options) : base(options)
        {
            _tenantAccessor = tenantAccessor;
            _connectionProvider = connectionProvider;
        }

        public virtual string Scheme { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var key = _tenantAccessor.CurrentTenant?.GetKey();
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            optionsBuilder.ReplaceService<IModelCacheKeyFactory, SchemaCacheKeyFactory>();
            optionsBuilder.ReplaceService<IMigrationsAssembly, SchemaMigrationAssembly>();
            _connectionProvider.UseDatabaseProvider(optionsBuilder, c =>
            {
                c.MigrationsHistoryTable(SchemaConstants.MigrationHistory, Scheme);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Scheme);
            base.OnModelCreating(modelBuilder);
        }
    }
}