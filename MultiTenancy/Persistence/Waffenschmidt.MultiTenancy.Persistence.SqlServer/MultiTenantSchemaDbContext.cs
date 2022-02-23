using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Waffenschmidt.MultiTenancy.Abstraction;
using Waffenschmidt.MultiTenancy.Persistence.Abstractions;

namespace Waffenschmidt.MultiTenancy.Persistence.SqlServer
{
    public class MultiTenantSchemaDbContext : SchemaSeparation.
        MultiTenantSchemaDbContext<SqlServerDbContextOptionsBuilder, SqlServerOptionsExtension>
    {
        public MultiTenantSchemaDbContext(ITenantAccessor tenantAccessor,
            IConnectionProvider<SqlServerDbContextOptionsBuilder, SqlServerOptionsExtension> connectionProvider,
            DbContextOptions options) : base(tenantAccessor, connectionProvider, options)
        {
        }
    }
}