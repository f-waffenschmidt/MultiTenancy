using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using MultiTenancy.Abstraction;
using MultiTenancy.Persistence.Abstractions;
using MultiTenancy.Persistence.SchemaSeparation;
using Waffenschmidt.MultiTenancy.Persistence.SchemaSeparation;

namespace MultiTenancy.Persistence.SqlServer
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