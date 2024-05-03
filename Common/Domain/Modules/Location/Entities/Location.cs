using NetTopologySuite.Geometries;
using Trace.Common.Domain.Modules.Location.Enum;

namespace Trace.Common.Domain.Modules.Location.Entities;

public class Location : TaggedEntity<Guid> {
    public string? OsmId { get; set; }

    public bool Default { get; set; }

    public bool Custom { get; set; }

    public string Name { get; set; } = String.Empty;

    public string? Address { get; set; }

    public DateTimeOffset? ApprovedAt { get; set; }

    public string? ApprovedBy { get; set; }

    public LocationType? Type { get; set; }

    public LocationCategory? Category { get; set; }

    public Guid? CategoryId { get; set; }

    public Geometry Shape { get; set; } = null!;

    public string Description { get; set; } = String.Empty;
}