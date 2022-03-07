using System;
using System.Threading.Tasks;

namespace Florez4Code.MultiTenancy.Abstraction
{
    public interface ITenantManager<T> where T: Tenant, new()
    {
        Task<T> FindByIdAsync(Guid validTenantFromPath);
    }
}