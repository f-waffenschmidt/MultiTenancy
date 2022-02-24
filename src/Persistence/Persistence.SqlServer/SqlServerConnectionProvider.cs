using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Florez4Code.MultiTenancy.Abstraction;
using Florez4Code.MultiTenancy.Persistence.Abstractions;

namespace Florez4Code.MultiTenancy.Persistence.SqlServer
{
    public class SqlServerConnectionProvider : IConnectionProvider<SqlServerDbContextOptionsBuilder, SqlServerOptionsExtension>
    {
        private readonly ITenantAccessor _tenantAccessor;

        public SqlServerConnectionProvider(ITenantAccessor tenantAccessor)
        {
            _tenantAccessor = tenantAccessor;
        }
        public DbConnectionConfiguration GetDbConnectionConfiguration()
        {
            throw new NotImplementedException();
        }

        public void UseDatabaseProvider(DbContextOptionsBuilder dbContextOptionsBuilder,
            Action<RelationalDbContextOptionsBuilder<SqlServerDbContextOptionsBuilder, SqlServerOptionsExtension>>
                action)
        {
            dbContextOptionsBuilder.UseSqlServer(GetDbConnectionConfiguration().ConnectionString, action);
        }
    }
}