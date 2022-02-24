using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Pistolsmith.MultiTenancy.Abstraction;
using Pistolsmith.MultiTenancy.Persistence.Abstractions;
using Pistolsmith.MultiTenancy.Persistence.SchemaSeparation;

namespace Pistolsmith.MultiTenancy.Persistence.SqlServer
{
    public class MultiTenantSchemaDbContext : MultiTenantSchemaDbContext<SqlServerDbContextOptionsBuilder, SqlServerOptionsExtension>
    {
        public MultiTenantSchemaDbContext(ITenantAccessor tenantAccessor,
            IConnectionProvider<SqlServerDbContextOptionsBuilder, SqlServerOptionsExtension> connectionProvider,
            DbContextOptions options) : base(tenantAccessor, connectionProvider, options)
        {
        }
    }
}