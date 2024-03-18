namespace Trace.Common.Domain.Modules.Tag.Entities;

public class TagMember : TenantEntity<Guid> {
    public DateTimeOffset? Expiry { get; set; }
}