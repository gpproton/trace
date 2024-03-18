namespace Trace.Common.Domain.Modules.Customer.Entities;

public class Customer : TenantEntity<Guid> {
    public Guid ApiIKey { get; set; }

    public bool Active { get; set; }

    public string Name { get; set; } = string.Empty;

    public string ShortName { get; set; } = string.Empty;
}