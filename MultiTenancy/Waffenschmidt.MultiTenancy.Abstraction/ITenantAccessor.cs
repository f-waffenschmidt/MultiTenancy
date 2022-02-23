namespace Waffenschmidt.MultiTenancy.Abstraction
{
    public interface ITenantAccessor
    {
        Tenant CurrentTenant { get; }
    }
}