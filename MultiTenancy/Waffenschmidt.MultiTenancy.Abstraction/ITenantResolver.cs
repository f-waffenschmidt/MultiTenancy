using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace Waffenschmidt.MultiTenancy.Abstraction
{
    public interface ITenantResolver<T> where T: Tenant
    {
        Task ResolveTenantAsync(HttpContext httpContext);
    }
}