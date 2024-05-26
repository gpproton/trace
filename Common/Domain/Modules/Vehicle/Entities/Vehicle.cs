using Trace.Common.Domain.Modules.Asset.Enums;
using Trace.Common.Domain.Modules.Asset.Shared;

namespace Trace.Common.Domain.Modules.Vehicle.Entities;

public sealed class Vehicle : AssetEntity {
    public string Name { get; set; } = null!;

    public VehicleType Type { get; set; }

    public string FleetIdentifier { get; set; } = String.Empty;

    public string RegistrationId { get; set; } = null!;

    public long Odometer { get; set; }

    public FuelType FuelType { get; set; }

    public int FuelCapacity { get; set; }

    public int HorsePower { get; set; }

    public string Model { get; set; } = null!;

    public decimal WeightCapacity { get; set; }

    public decimal AxleWeightCapacity { get; set; }

    // public Guid? TrailerId { get; set; }
}