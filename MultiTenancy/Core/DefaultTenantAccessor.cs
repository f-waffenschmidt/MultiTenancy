using System;
using System.Threading;

namespace MultiTenancy.Abstraction.Default
{
    /// <summary>
    /// DefaultTenantAccessor
    /// </summary>
    public class DefaultTenantAccessor : ITenantAccessor, IDisposable
    {

        private static readonly AsyncLocal<Tenant> _currentTenant = new AsyncLocal<Tenant>();

        public Tenant CurrentTenant
        {
            get => _currentTenant.Value;

            set
            {
                if (value != null)
                {
                    // Use an object indirection to hold the HttpContext in the AsyncLocal,
                    // so it can be cleared in all ExecutionContexts when its cleared.
                    _currentTenant.Value = value;
                }
            }
        }

        public DefaultTenantAccessor(Tenant tenant)
        {
            _currentTenant.Value = tenant;
        }

        public DefaultTenantAccessor()
        {

        }

        public void Dispose()
        {
        }
    }

}