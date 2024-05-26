namespace Trace.Common.Domain.Modules.Route.Entities;

public class Route : TaggedEntity<Guid> {
    public Guid? ApprovedBy { get; set; }
    public DateTimeOffset ApprovedAt { get; set; }
    public string? Color { get; set; }
    public int? SpeedLimit { get; set; }
    public decimal RestDuration { get; set; }
    public decimal ToleranceDuration { get; set; }
    public int? CompletedRate { get; set; }
    public virtual Location.Entities.Location Source { get; set; } = null!;
    public Guid? SourceId { get; set; }
    public virtual Location.Entities.Location Destination { get; set; } = null!;
    public Guid? DestinationId { get; set; }
}