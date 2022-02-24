using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pistolsmith.MultiTenancy.Abstraction;

namespace Pistolsmith.MultiTenancy.Core.Resolver
{
    public class QueryTenantResolver : ITenantResolver<Tenant> 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public QueryTenantResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Task<Tenant> GetTenantAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}