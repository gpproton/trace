namespace Trace.Common.Domain.Permission;

public class PermissionItem {
    public PermissionItem(Module module, string featureId, RoleLevel role, bool[] actions) {
        this.Module = module;
        this.FeatureId = featureId;
        this.Role = role;
        this.Actions = actions;
    }

    public Module Module { get; init; }
    public string FeatureId { get; init; }
    public RoleLevel Role { get; init; }
    // Read, Create, Update, Delete
    public bool[] Actions { get; init; }
}