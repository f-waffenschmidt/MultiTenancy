using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Florez4Code.MultiTenancy.Abstraction
{
    public interface ITenantProcessor<T> where T: Tenant
    {
        Task<T> ProcessTenantAsync(HttpContext httpContext);
    }
}