using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MultiTenancy.Abstraction.Default
{
    public interface ITenantResolver<T> where T : Tenant
    {
        Task<T> GetTenantAsync();
    }
}