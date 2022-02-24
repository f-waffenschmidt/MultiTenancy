using System;

namespace Florez4Code.MultiTenancy.Abstraction
{
    public class Tenant
    {
        public Guid ExternalId { get; set; }
        public string Name { get; set; }
        
        public bool Enabled { get; set; }
        
        public virtual string GetKey()
        {
            return Name;
        }
    }
}