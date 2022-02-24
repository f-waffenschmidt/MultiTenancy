﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MultiTenancy.Abstraction;
using MultiTenancy.Abstraction.Default;

namespace MultiTenancy.Core.Resolver
{
    public class StaticTenantResolver : ITenantResolver<Tenant>
    {
        private readonly MultiTenancyOptions _multiTenancyOptions;

        public StaticTenantResolver(MultiTenancyOptions multiTenancyOptions)
        {
            _multiTenancyOptions = multiTenancyOptions;
        }

        public Task<Tenant> GetTenantAsync()
        {
            return _multiTenancyOptions.StaticTenant.Enabled
                ? Task.FromResult<Tenant>(_multiTenancyOptions.StaticTenant)
                : Task.FromResult<Tenant>(null);
        }
    }

    public class MultiTenancyOptions
    {
        public StaticTenant StaticTenant { get; set; }
    }

    public class StaticTenant : Tenant
    {
        public bool Enabled { get; set; }
    }
}