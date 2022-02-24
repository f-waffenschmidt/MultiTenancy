using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MultiTenancy.Abstraction
{
    public interface ITenantProcessor<T> where T: Tenant
    {
        Task<T> ProcessTenantAsync(HttpContext httpContext);
    }
}