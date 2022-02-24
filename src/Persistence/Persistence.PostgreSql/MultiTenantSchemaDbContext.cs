using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using Pistolsmith.MultiTenancy.Abstraction;
using Pistolsmith.MultiTenancy.Persistence.Abstractions;
using Pistolsmith.MultiTenancy.Persistence.SchemaSeparation;

namespace Pistolsmith.MultiTenancy.Persistence.PostgreSql
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