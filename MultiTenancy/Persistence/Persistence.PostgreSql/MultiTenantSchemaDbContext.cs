using Microsoft.EntityFrameworkCore;
using MultiTenancy.Abstraction;
using MultiTenancy.Persistence.Abstractions;
using MultiTenancy.Persistence.SchemaSeparation;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace MultiTenancy.Persistence.PostgreSql
{
    public class MultiTenantSchemaDbContext : MultiTenantSchemaDbContext<NpgsqlDbContextOptionsBuilder, NpgsqlOptionsExtension>
    {
        public MultiTenantSchemaDbContext(ITenantAccessor tenantAccessor,
            IConnectionProvider<NpgsqlDbContextOptionsBuilder, NpgsqlOptionsExtension> connectionProvider,
            DbContextOptions options) : base(tenantAccessor, connectionProvider, options)
        {
        }
    }
}