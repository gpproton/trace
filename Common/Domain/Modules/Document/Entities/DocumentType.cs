namespace Trace.Common.Domain.Modules.Document.Entities;

public class DocumentType : TypedEntity<Guid> {
    public string Icon { get; set; } = String.Empty;

    public string? Feature { get; set; }
}