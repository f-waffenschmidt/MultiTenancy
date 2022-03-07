using System;
using System.Linq;
using System.Threading.Tasks;

namespace Florez4Code.MultiTenancy.Abstraction
{
    public interface ITenantProvider<T> where T : Tenant
    {

        Task<T> FindByIdAsync(Guid tenantId);
    }
}