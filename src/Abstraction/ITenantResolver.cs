using System.Threading.Tasks;

namespace Florez4Code.MultiTenancy.Abstraction
{
    public interface ITenantResolver<T> where T : Tenant
    {
        Task<T> GetTenantAsync();
    }
}