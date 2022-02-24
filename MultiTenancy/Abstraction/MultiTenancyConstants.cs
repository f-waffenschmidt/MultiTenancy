namespace MultiTenancy.Abstraction
{
    public class MultiTenancyConstants
    {
        public const string ConfigurationSection = "MultiTenancy";

        public class ClaimConstants
        {
            public const string TenantClaimType = "tenant";
            public const string TenantIdClaimType = "tenantId";
        }
    }
}