using System.Threading.Tasks;

namespace Pistolsmith.MultiTenancy.Abstraction
{
    public interface ITenantResolver<T> where T : Tenant
    {
        Task<T> GetTenantAsync();
    }
}