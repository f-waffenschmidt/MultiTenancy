namespace Pistolsmith.MultiTenancy.Persistence.SchemaSeparation
{
    public interface ISchemeDbContext
    {
        string Scheme { get; }
    }
}