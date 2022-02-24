using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Florez4Code.MultiTenancy.Persistence.SchemaSeparation
{
    public abstract class SchemaMigration : Migration
    {
        /// <summary>
        /// Migration to schema
        /// </summary>
        protected readonly string _scheme;

        /// <summary>
        /// Create an instance of SchemaMigration with a specific schema
        /// </summary>
        /// <param name="scheme"></param>
        public SchemaMigration(string scheme)
        {
            _scheme = scheme ?? throw new ArgumentNullException(nameof(scheme));
        }


    }
}