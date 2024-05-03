namespace Trace.Common.Domain.Permission;

public interface IPermission {
    IEnumerable<PermissionItem> Result();
}