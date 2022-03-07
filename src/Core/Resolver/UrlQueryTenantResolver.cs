using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Florez4Code.MultiTenancy.Abstraction;
using Florez4Code.MultiTenancy.Core.Extensions;

namespace Florez4Code.MultiTenancy.Core.Resolver
{
    public class QueryTenantResolver<T> : ITenantResolver<T> where T: Tenant, new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITenantManager<T> _tenantManager;

        public QueryTenantResolver(IHttpContextAccessor httpContextAccessor, ITenantManager<T> tenantManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _tenantManager = tenantManager;
        }

        public async Task<T> GetTenantAsync()
        {
            var context = _httpContextAccessor.EnsureHttpContext();

            var paramsFromQuery = context.GetParameters();
            if (paramsFromQuery.HasKeys() && !string.IsNullOrEmpty(paramsFromQuery.Get("tenant_id")) &&
                Guid.TryParse(paramsFromQuery.Get("tenant_id"), out var tenantId))
            {
                var tenant = await _tenantManager.FindByIdAsync(tenantId);
                return tenant;
            }

            return null;
        }
    }
}