using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace Waffenschmidt.MultiTenancy.Persistence.SchemaSeparation
{
    public class SchemaMigrationAssembly : MigrationsAssembly
    {
        /// <summary>
        /// Db context
        /// </summary>
        private readonly DbContext _context;

        private const BindingFlags ConstructorDefault = BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance;

        /// <summary>
        /// Creates an instance of SchemaMigrationAssembly 
        /// </summary>
        /// <param name="currentContext"></param>
        /// <param name="options"></param>
        /// <param name="idGenerator"></param>
        /// <param name="logger"></param>
        public SchemaMigrationAssembly(ICurrentDbContext currentContext,
            IDbContextOptions options, IMigrationsIdGenerator idGenerator,
            IDiagnosticsLogger<DbLoggerCategory.Migrations> logger)
            : base(currentContext, options, idGenerator, logger)
        {
            _context = currentContext.Context;
        }

        public override Migration CreateMigration(TypeInfo migrationClass,
            string activeProvider)
        {
            if (activeProvider == null)
                throw new ArgumentNullException(nameof(activeProvider));

            var hasCtorWithSchema = migrationClass.BaseType
                .GetConstructor(new[] { typeof(string) }) != null;

            if (hasCtorWithSchema && _context is ISchemeDbContext schema)
            {
                var path = Assembly.GetAssembly(migrationClass.AsType()).Location;

                var instance = (Migration)Activator.CreateInstanceFrom(path, migrationClass.FullName, false,
                    ConstructorDefault, null, new object?[] { schema.Scheme }, null, null).Unwrap();
                instance.ActiveProvider = activeProvider;
                return instance;
            }

            return base.CreateMigration(migrationClass, activeProvider);
        }
    }
}