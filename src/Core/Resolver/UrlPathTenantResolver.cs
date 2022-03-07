using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Florez4Code.MultiTenancy.Abstraction;
using Florez4Code.MultiTenancy.Core.Extensions;

namespace Florez4Code.MultiTenancy.Core.Resolver
{
    public class PathTenantResolver<T> : ITenantResolver<T> where T : Tenant, new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITenantManager<T> _tenantManager;

        public PathTenantResolver(IHttpContextAccessor httpContextAccessor, ITenantManager<T> tenantManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _tenantManager = tenantManager;
        }

        public async Task<T> GetTenantAsync()
        {
            _httpContextAccessor.EnsureHttpContext();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.Request.Path.HasValue)
            {
                var paths = httpContext.Request.Path.Value.Split("/", StringSplitOptions.RemoveEmptyEntries);
                if (paths.Any() && Guid.TryParse(paths.First(), out var validTenantFromPath))
                {
                    //We assume, the first segment is the tenant identifier
                    var tenant = await _tenantManager.FindByIdAsync(validTenantFromPath);
                    if (tenant != null)
                    {
                        httpContext.Request.Path = httpContext.Request.Path.ToString()
                            .Replace("/" + validTenantFromPath, string.Empty);
                    }

                    return tenant;
                }
            }

            return null;
        }
    }
}