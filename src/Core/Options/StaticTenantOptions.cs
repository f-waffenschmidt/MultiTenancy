using Florez4Code.MultiTenancy.Abstraction;

namespace Florez4Code.MultiTenancy.Core.Options
{
    public class StaticTenantOptions : Tenant
    {
        public bool Enabled { get; set; }
    }
}