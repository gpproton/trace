using Trace.Common.Domain.Modules.Asset.Shared;
using Trace.Common.Domain.Modules.Trailer.Enums;

namespace Trace.Common.Domain.Modules.Trailer.Entities;

public sealed class Trailer : AssetEntity {
    public TrailerType Type { get; set; }

    public string FleetIdentifier { get; set; } = String.Empty;

    public long Odometer { get; set; }

    public int HorsePower { get; set; }

    public string Model { get; set; } = null!;

    public decimal WeightCapacity { get; set; }

    public decimal AxleWeightCapacity { get; set; }
}