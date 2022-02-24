using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MultiTenancy.Abstraction;
using MultiTenancy.Abstraction.Default;

namespace MultiTenancy.Core.Middleware
{
    public class TenantResolveMiddleware<T> where T: Tenant
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TenantResolveMiddleware<T>> _logger;

        /// <summary>
        /// Creates a new instance of the middleware. Normally executed by the asp.net core framework
        /// </summary>
        /// <param name="next">The next delegate</param>
        /// <param name="logger">A logger</param>
        public TenantResolveMiddleware(RequestDelegate next, ILogger<TenantResolveMiddleware<T>> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Invokes this middleware and provides the necessary information to the <see cref="TenantAccessor"/>
        /// </summary>
        /// <param name="context">HttpContext to extract some information</param>
        /// <param name="tenantAccessor"></param>
        /// <param name="tenantProcessor">Resolver to extract the tenant information</param>
        /// <returns>A asynchronous task</returns>
        public async Task Invoke(HttpContext context, ITenantAccessor tenantAccessor, ITenantProcessor<T> tenantProcessor)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (tenantProcessor == null)
                throw new ArgumentNullException(nameof(tenantProcessor));
            if (tenantAccessor == null)
                throw new ArgumentNullException(nameof(tenantAccessor));



            _logger?.LogDebug("Resolving TenantContext using {TenantResolverType}", tenantProcessor.GetType().Name);
            var currentTenant = await tenantProcessor.ProcessTenantAsync(context);

            using var accessor = new DefaultTenantAccessor(currentTenant);
            tenantAccessor = accessor;
            _logger?.LogDebug("Resolved TenantContext to {Tenant}", tenantAccessor?.CurrentTenant?.Name);
            await _next.Invoke(context);
        }
    }
}