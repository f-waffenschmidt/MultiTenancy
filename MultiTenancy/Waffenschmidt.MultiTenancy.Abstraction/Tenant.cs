using System;
using System.Data.Common;

namespace Waffenschmidt.MultiTenancy.Abstraction
{
    public abstract class Tenant
    {
        public Guid ExternalId { get; set; }
        public string Name { get; set; }

        public virtual string GetKey()
        {
            return Name;
        }
    }
}