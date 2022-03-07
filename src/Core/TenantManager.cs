using System;
using System.Linq;
using System.Threading.Tasks;
using Florez4Code.MultiTenancy.Abstraction;

namespace Florez4Code.MultiTenancy.Core
{
    public class TenantManager<T> : ITenantManager<T> where T: Tenant, new()
    {
        private readonly ITenantProvider<T> _tenantProvider;

        public TenantManager(ITenantProvider<T> tenantProvider)
        {
            _tenantProvider = tenantProvider;
        }
        public async Task<T> FindByIdAsync(Guid tenantId)
        {
            var tenant = await _tenantProvider.FindByIdAsync(tenantId);
            return tenant;
        }
    }
}