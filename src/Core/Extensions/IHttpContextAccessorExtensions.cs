using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Florez4Code.MultiTenancy.Core.Extensions
{
    public static class IHttpContextAccessorExtensions
    {
        public static HttpContext EnsureHttpContext(this IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor?.HttpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));
            }

            return httpContextAccessor.HttpContext;
        }
        public static NameValueCollection? GetParameters(this HttpContext context)
        {
            var nameValueCollection = new NameValueCollection();
            if (context?.Request?.Query == null) return null;
            foreach (KeyValuePair<string, StringValues> keyValuePair in context?.Request?.Query)
                nameValueCollection.Add(keyValuePair.Key, keyValuePair.Value.First<string>());
            return nameValueCollection;

        }
    }
}