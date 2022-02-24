using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using Florez4Code.MultiTenancy.Abstraction;
using Florez4Code.MultiTenancy.Persistence.Abstractions;
using Florez4Code.MultiTenancy.Persistence.SchemaSeparation;

namespace Florez4Code.MultiTenancy.Persistence.PostgreSql
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