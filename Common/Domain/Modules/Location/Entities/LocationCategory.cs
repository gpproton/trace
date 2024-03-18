namespace Trace.Common.Domain.Modules.Location.Entities;

public class LocationCategory : TypedEntity<Guid> {
    public string Icon { get; set; } = String.Empty;
}