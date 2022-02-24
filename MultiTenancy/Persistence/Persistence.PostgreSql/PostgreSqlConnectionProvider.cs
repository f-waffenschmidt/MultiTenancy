using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MultiTenancy.Abstraction;
using MultiTenancy.Persistence.Abstractions;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace MultiTenancy.Persistence.PostgreSql
{
    public class SqlServerConnectionProvider : IConnectionProvider<NpgsqlDbContextOptionsBuilder, NpgsqlOptionsExtension>
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
            Action<RelationalDbContextOptionsBuilder<NpgsqlDbContextOptionsBuilder, NpgsqlOptionsExtension>>
                action)
        {
            dbContextOptionsBuilder.UseNpgsql(GetDbConnectionConfiguration().ConnectionString, action);
        }
    }
}