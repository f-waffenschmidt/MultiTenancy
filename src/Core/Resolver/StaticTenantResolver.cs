using System.Threading.Tasks;
using Florez4Code.MultiTenancy.Abstraction;

namespace Florez4Code.MultiTenancy.Core.Resolver
{
    public class StaticTenantResolver : ITenantResolver<Tenant>
    {
        private readonly MultiTenancyOptions _multiTenancyOptions;

        public StaticTenantResolver(MultiTenancyOptions multiTenancyOptions)
        {
            _multiTenancyOptions = multiTenancyOptions;
        }

        public Task<Tenant> GetTenantAsync()
        {
            return _multiTenancyOptions.StaticTenant.Enabled
                ? Task.FromResult<Tenant>(_multiTenancyOptions.StaticTenant)
                : Task.FromResult<Tenant>(null);
        }
    }

    public class MultiTenancyOptions
    {
        public StaticTenant StaticTenant { get; set; }
    }

    public class StaticTenant : Tenant
    {
        public bool Enabled { get; set; }
    }
}