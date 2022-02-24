using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MultiTenancy.Abstraction;
using MultiTenancy.Abstraction.Default;

namespace MultiTenancy.Core.Resolver
{
    public class PathTenantResolver : ITenantResolver<Tenant>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PathTenantResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Task<Tenant> GetTenantAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}