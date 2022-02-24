using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Pistolsmith.MultiTenancy.Persistence.SchemaSeparation
{
    public class SchemaCacheKeyFactory : IModelCacheKeyFactory
    {

        /// <summary>
        /// Retrieve schema for a schematic database context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetSchema(DbContext context)
        {
            var schemaContext = context as ISchemeDbContext;
            if (string.IsNullOrEmpty(schemaContext?.Scheme))
            {
                return SchemaConstants.Default;
            }

            return schemaContext?.Scheme;
        }

        /// <summary>
        /// Creates a cache key based on schema and database context type
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Create(DbContext context)
        {
            return new
            {
                Type = context.GetType(),
                Scheme = GetSchema(context)
            };
        }
    }
}