using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Waffenschmidt.MultiTenancy.Abstraction;

namespace Waffenschmidt.MultiTenancy.Persistence.Abstractions
{

    public interface IConnectionProvider<TBuilder, TExtension> where TBuilder : RelationalDbContextOptionsBuilder<TBuilder, TExtension>
        where TExtension : RelationalOptionsExtension, new() 
    {
        DbConnectionConfiguration GetDbConnectionConfiguration();
        void UseDatabaseProvider(DbContextOptionsBuilder dbContextOptionsBuilder,
            Action<RelationalDbContextOptionsBuilder<TBuilder, TExtension>> action);
    }

    public class DbConnectionConfiguration
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
    }
}