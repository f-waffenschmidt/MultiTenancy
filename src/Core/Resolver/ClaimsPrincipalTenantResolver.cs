using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Florez4Code.MultiTenancy.Abstraction;

namespace Florez4Code.MultiTenancy.Core.Resolver
{
    public class ClaimsPrincipalTenantResolver : ITenantResolver<Tenant>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsPrincipalTenantResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public virtual Task<Tenant> GetTenantAsync()
        {
            var httpContext = _httpContextAccessor?.HttpContext;
            if (httpContext == null) return Task.FromResult<Tenant>(null);
            
            if (httpContext.User?.Identity?.IsAuthenticated == true)
            {
                return Task.FromResult(new Tenant()
                {
                    Name = httpContext.User
                               .FindFirst(p => p.Type == MultiTenancyConstants.ClaimConstants.TenantClaimType)
                               ?.Value ??
                           throw new ArgumentNullException(MultiTenancyConstants.ClaimConstants.TenantClaimType),
                    ExternalId =
                        Guid.Parse(
                            httpContext.User
                                .FindFirst(p => p.Type == MultiTenancyConstants.ClaimConstants.TenantIdClaimType)
                                ?.Value ??
                            throw new ArgumentNullException(MultiTenancyConstants.ClaimConstants.TenantIdClaimType))
                })!;
            }

            return Task.FromResult<Tenant>(null);
        }
    }
}