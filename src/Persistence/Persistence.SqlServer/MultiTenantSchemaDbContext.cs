using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Florez4Code.MultiTenancy.Abstraction;
using Florez4Code.MultiTenancy.Persistence.Abstractions;
using Florez4Code.MultiTenancy.Persistence.SchemaSeparation;

namespace Florez4Code.MultiTenancy.Persistence.SqlServer
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