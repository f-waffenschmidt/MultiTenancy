namespace Pistolsmith.MultiTenancy.Abstraction
{
    public interface ITenantAccessor
    {
        Tenant CurrentTenant { get; }
    }
}