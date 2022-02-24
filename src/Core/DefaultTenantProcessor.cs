using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Florez4Code.MultiTenancy.Abstraction;

namespace Florez4Code.MultiTenancy.Core
{
    /// <summary>
    /// DefaultTenantResolver
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DefaultTenantResolver<T> : ITenantProcessor<T> where T : Tenant, new()
    {
        private readonly IEnumerable<ITenantResolver<T>> _tenantResolvers;

        public DefaultTenantResolver(IEnumerable<ITenantResolver<T>> tenantResolvers)
        {
            _tenantResolvers = tenantResolvers;
        }

        /// <summary>
        /// ResolveTenantAsync
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public virtual async Task<T> ProcessTenantAsync(HttpContext httpContext)
        {
            foreach (var resolver in _tenantResolvers)
            {
                T tenant = await resolver.GetTenantAsync();
                if (tenant != null)
                {
                    return tenant;
                }
            }
            return null!;
        }
    }
}