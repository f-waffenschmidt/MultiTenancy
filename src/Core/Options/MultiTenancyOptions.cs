using System.Collections.Generic;
using System.Linq;
using Florez4Code.MultiTenancy.Abstraction;

namespace Florez4Code.MultiTenancy.Core.Options
{
    public class MultiTenancyOptions
    {
        public StaticTenantOptions StaticTenant { get; set; }

        public TenantProviderOptions Tenants { get; set; }
    }

    public class TenantProviderOptions : List<Tenant>
    {
    }
}