namespace Trace.Common.Domain.Permission;

public enum RoleLevel {
    // Default roles
    Default,
    Anonymous,
    Bot,

    // Customer roles
    CustomerClient,
    CustomerBasic,
    CustomerOperator,
    CustomerAdministrator,

    // Tenant roles
    TenantDriver,
    TenantLoadSupervisor,
    TenantWarehouseManager,
    TenantDriverSupervisor,
    TenantDriverManager,
    TenantFleetMember,
    TenantFleetLead,
    TenantFleetManager,
    TenantAdministrator,
    TenantSuperAdministrator,

    // System roles
    SystemBot,
    SystemOperator,
    SystemAdministrator,
    SystemSuperAdministrator
}