using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MultiTenancy.Persistence.Abstractions
{

    /// <summary>
    /// IConnectionProvider
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    /// <typeparam name="TExtension"></typeparam>
    public interface IConnectionProvider<TBuilder, TExtension> where TBuilder : RelationalDbContextOptionsBuilder<TBuilder, TExtension>
        where TExtension : RelationalOptionsExtension, new() 
    {
        /// <summary>
        /// GetDbConnectionConfiguration
        /// </summary>
        /// <returns></returns>
        DbConnectionConfiguration GetDbConnectionConfiguration();
        /// <summary>
        /// UseDatabaseProvider
        /// </summary>
        /// <param name="dbContextOptionsBuilder"></param>
        /// <param name="action"></param>
        void UseDatabaseProvider(DbContextOptionsBuilder dbContextOptionsBuilder,
            Action<RelationalDbContextOptionsBuilder<TBuilder, TExtension>> action);
    }
}