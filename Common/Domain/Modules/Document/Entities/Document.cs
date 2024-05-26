using Trace.Common.Domain.Modules.Document.Enums;

namespace Trace.Common.Domain.Modules.Document.Entities;

public class Document : TenantEntity<Guid> {
    public string UniqueId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public virtual DocumentType Type { get; set; } = null!;

    public DocumentStatus Status { get; set; } = DocumentStatus.Original;

    public string Path { get; set; } = string.Empty;

    public string Extension { get; set; } = string.Empty;

    public DateTimeOffset? ApprovedAt { get; set; }

    public string? ApprovedBy { get; set; }

    public string Mime { get; set; } = string.Empty;

    public string? Description { get; set; }
}