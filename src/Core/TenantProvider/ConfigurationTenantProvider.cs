using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Florez4Code.MultiTenancy.Abstraction;
using Florez4Code.MultiTenancy.Core.Options;
using Microsoft.Extensions.Options;

namespace Florez4Code.MultiTenancy.Core.TenantProvider
{
    public class ConfigurationTenantProvider<T> : ITenantProvider<T> where T : Tenant
    {
        private readonly IOptions<MultiTenancyOptions> _options;

        public ConfigurationTenantProvider(IOptions<MultiTenancyOptions> options)
        {
            _options = options;
        }

        public List<T> Tenants => _options.Value.Tenants as List<T>;

        public Task<T> FindByIdAsync(Guid tenantId)
        {
            return Task.FromResult<T>(Tenants.FirstOrDefault(p => p.ExternalId == tenantId) as T);
        }
    }
}