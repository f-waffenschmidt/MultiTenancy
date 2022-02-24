namespace Florez4Code.MultiTenancy.Abstraction
{
    public interface ITenantAccessor
    {
        Tenant CurrentTenant { get; }
    }
}