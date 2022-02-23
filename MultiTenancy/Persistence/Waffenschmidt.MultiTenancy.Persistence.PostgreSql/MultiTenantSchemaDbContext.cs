using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using Waffenschmidt.MultiTenancy.Abstraction;
using Waffenschmidt.MultiTenancy.Persistence.Abstractions;

namespace Waffenschmidt.MultiTenancy.Persistence.PostgreSql
{
    public class MultiTenantSchemaDbContext : SchemaSeparation.
        MultiTenantSchemaDbContext<NpgsqlDbContextOptionsBuilder, NpgsqlOptionsExtension>
    {
        public MultiTenantSchemaDbContext(ITenantAccessor tenantAccessor,
            IConnectionProvider<NpgsqlDbContextOptionsBuilder, NpgsqlOptionsExtension> connectionProvider,
            DbContextOptions options) : base(tenantAccessor, connectionProvider, options)
        {
        }
    }
}