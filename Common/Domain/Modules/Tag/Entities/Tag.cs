namespace Trace.Common.Domain.Modules.Tag.Entities;

public class Tag : TenantEntity<Guid> {
    public string? Color { get; set; }
}