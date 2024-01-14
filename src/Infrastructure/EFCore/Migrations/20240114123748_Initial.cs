using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Trace.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "account_setting",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    map_auto_invoice = table.Column<bool>(type: "boolean", nullable: false),
                    map_auto_order = table.Column<bool>(type: "boolean", nullable: false),
                    map_auto_route = table.Column<bool>(type: "boolean", nullable: false),
                    map_auto_route_cost = table.Column<bool>(type: "boolean", nullable: false),
                    map_auto_zone_otp = table.Column<bool>(type: "boolean", nullable: false),
                    map_bing_api_key = table.Column<string>(type: "text", nullable: true),
                    map_enable_trip = table.Column<bool>(type: "boolean", nullable: false),
                    map_google_api_key = table.Column<string>(type: "text", nullable: true),
                    map_map_box_api_key = table.Column<string>(type: "text", nullable: true),
                    map_map_type = table.Column<string>(type: "text", nullable: true),
                    map_verify_otp = table.Column<bool>(type: "boolean", nullable: false),
                    map_zoom = table.Column<int>(type: "integer", nullable: true),
                    map_zoom_selection = table.Column<int>(type: "integer", nullable: true),
                    option_hour24time = table.Column<bool>(type: "boolean", nullable: false),
                    option_language = table.Column<string>(type: "text", nullable: true),
                    option_timezone = table.Column<string>(type: "text", nullable: true),
                    option_token = table.Column<string>(type: "text", nullable: true),
                    option_unit_area = table.Column<string>(type: "text", nullable: true),
                    option_unit_distance = table.Column<string>(type: "text", nullable: true),
                    option_unit_force = table.Column<string>(type: "text", nullable: true),
                    option_unit_power = table.Column<string>(type: "text", nullable: true),
                    option_unit_pressure = table.Column<string>(type: "text", nullable: true),
                    option_unit_speed = table.Column<string>(type: "text", nullable: true),
                    option_unit_temperature = table.Column<string>(type: "text", nullable: true),
                    option_unit_volume = table.Column<string>(type: "text", nullable: true),
                    option_unit_weight = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_setting", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    root = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "asset_category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    color = table.Column<string>(type: "text", nullable: true),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asset_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    phone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    first_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    middle_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    last_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    expiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_active = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    address_birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    address_children_count = table.Column<int>(type: "integer", nullable: false),
                    address_city = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address_country = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    address_county = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address_guarantor_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    address_guarantor_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    address_guarantor_phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address_home_phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    address_kin_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    address_kin_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    address_kin_phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address_line1 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    address_line2 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    address_married = table.Column<bool>(type: "boolean", nullable: false),
                    address_phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    address_state = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address_zip = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contact", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "device",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    unique_id = table.Column<string>(type: "text", nullable: false),
                    position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    last_update = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_moved = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    speed_limit = table.Column<int>(type: "integer", nullable: false),
                    expiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "device_command",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    delay = table.Column<int>(type: "integer", nullable: false),
                    messages = table.Column<string>(type: "text", nullable: false),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_command", x => new { x.id, x.tenant_id });
                });

            migrationBuilder.CreateTable(
                name: "location_category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_location_category", x => new { x.name, x.tenant_id });
                });

            migrationBuilder.CreateTable(
                name: "opportunity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_opportunity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organization",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    address_city = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address_country = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    address_county = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address_home_phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    address_line1 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    address_line2 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    address_phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    address_state = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address_zip = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organization", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    approved_by = table.Column<Guid>(type: "uuid", nullable: true),
                    approved_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    color = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    speed_limit = table.Column<int>(type: "integer", nullable: true),
                    rest_duration = table.Column<decimal>(type: "numeric", nullable: false),
                    tolerance_duration = table.Column<decimal>(type: "numeric", nullable: false),
                    completed_rate = table.Column<int>(type: "integer", nullable: true),
                    source = table.Column<Point>(type: "geometry", nullable: false),
                    destination = table.Column<Point>(type: "geometry", nullable: false),
                    path = table.Column<LineString>(type: "geometry", nullable: true),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_routes", x => new { x.name, x.tenant_id });
                });

            migrationBuilder.CreateTable(
                name: "server_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    api_key_google = table.Column<string>(type: "text", nullable: true),
                    api_key_microsoft = table.Column<string>(type: "text", nullable: true),
                    map_auto_invoice = table.Column<bool>(type: "boolean", nullable: false),
                    map_auto_order = table.Column<bool>(type: "boolean", nullable: false),
                    map_auto_route = table.Column<bool>(type: "boolean", nullable: false),
                    map_auto_route_cost = table.Column<bool>(type: "boolean", nullable: false),
                    map_auto_zone_otp = table.Column<bool>(type: "boolean", nullable: false),
                    map_bing_api_key = table.Column<string>(type: "text", nullable: true),
                    map_enable_trip = table.Column<bool>(type: "boolean", nullable: false),
                    map_google_api_key = table.Column<string>(type: "text", nullable: true),
                    map_map_box_api_key = table.Column<string>(type: "text", nullable: true),
                    map_map_type = table.Column<string>(type: "text", nullable: true),
                    map_verify_otp = table.Column<bool>(type: "boolean", nullable: false),
                    map_zoom = table.Column<int>(type: "integer", nullable: true),
                    map_zoom_selection = table.Column<int>(type: "integer", nullable: true),
                    setting_hour24time = table.Column<bool>(type: "boolean", nullable: false),
                    setting_language = table.Column<string>(type: "text", nullable: true),
                    setting_timezone = table.Column<string>(type: "text", nullable: true),
                    setting_token = table.Column<string>(type: "text", nullable: true),
                    setting_unit_area = table.Column<string>(type: "text", nullable: true),
                    setting_unit_distance = table.Column<string>(type: "text", nullable: true),
                    setting_unit_force = table.Column<string>(type: "text", nullable: true),
                    setting_unit_power = table.Column<string>(type: "text", nullable: true),
                    setting_unit_pressure = table.Column<string>(type: "text", nullable: true),
                    setting_unit_speed = table.Column<string>(type: "text", nullable: true),
                    setting_unit_temperature = table.Column<string>(type: "text", nullable: true),
                    setting_unit_volume = table.Column<string>(type: "text", nullable: true),
                    setting_unit_weight = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_server_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenant_setting",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    map_auto_invoice = table.Column<bool>(type: "boolean", nullable: false),
                    map_auto_order = table.Column<bool>(type: "boolean", nullable: false),
                    map_auto_route = table.Column<bool>(type: "boolean", nullable: false),
                    map_auto_route_cost = table.Column<bool>(type: "boolean", nullable: false),
                    map_auto_zone_otp = table.Column<bool>(type: "boolean", nullable: false),
                    map_bing_api_key = table.Column<string>(type: "text", nullable: true),
                    map_enable_trip = table.Column<bool>(type: "boolean", nullable: false),
                    map_google_api_key = table.Column<string>(type: "text", nullable: true),
                    map_map_box_api_key = table.Column<string>(type: "text", nullable: true),
                    map_map_type = table.Column<string>(type: "text", nullable: true),
                    map_verify_otp = table.Column<bool>(type: "boolean", nullable: false),
                    map_zoom = table.Column<int>(type: "integer", nullable: true),
                    map_zoom_selection = table.Column<int>(type: "integer", nullable: true),
                    option_hour24time = table.Column<bool>(type: "boolean", nullable: false),
                    option_language = table.Column<string>(type: "text", nullable: true),
                    option_timezone = table.Column<string>(type: "text", nullable: true),
                    option_token = table.Column<string>(type: "text", nullable: true),
                    option_unit_area = table.Column<string>(type: "text", nullable: true),
                    option_unit_distance = table.Column<string>(type: "text", nullable: true),
                    option_unit_force = table.Column<string>(type: "text", nullable: true),
                    option_unit_power = table.Column<string>(type: "text", nullable: true),
                    option_unit_pressure = table.Column<string>(type: "text", nullable: true),
                    option_unit_speed = table.Column<string>(type: "text", nullable: true),
                    option_unit_temperature = table.Column<string>(type: "text", nullable: true),
                    option_unit_volume = table.Column<string>(type: "text", nullable: true),
                    option_unit_weight = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_setting", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: true),
                    module = table.Column<string>(type: "text", nullable: true),
                    feature = table.Column<string>(type: "text", nullable: true),
                    actions_create = table.Column<bool>(type: "boolean", nullable: false),
                    actions_delete = table.Column<bool>(type: "boolean", nullable: false),
                    actions_read = table.Column<bool>(type: "boolean", nullable: false),
                    actions_update = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_permissions_user_role_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "asset",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    serial_number = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    barcode = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    color = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    deployed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    decommissioned = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asset", x => x.id);
                    table.ForeignKey(
                        name: "fk_asset_asset_category_category_id",
                        column: x => x.category_id,
                        principalTable: "asset_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trailer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    fleet_identifier = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    odometer = table.Column<long>(type: "bigint", nullable: false),
                    horse_power = table.Column<int>(type: "integer", nullable: false),
                    model = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    weight_capacity = table.Column<decimal>(type: "numeric", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    serial_number = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    barcode = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    color = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    deployed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    decommissioned = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trailer", x => new { x.name, x.tenant_id });
                    table.ForeignKey(
                        name: "fk_trailer_asset_category_category_id",
                        column: x => x.category_id,
                        principalTable: "asset_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    registration_no = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    fleet_identifier = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    odometer = table.Column<long>(type: "bigint", nullable: false),
                    fuel_type = table.Column<int>(type: "integer", nullable: false),
                    fuel_capacity = table.Column<int>(type: "integer", nullable: false),
                    horse_power = table.Column<int>(type: "integer", nullable: false),
                    model = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    weight_capacity = table.Column<decimal>(type: "numeric", nullable: false),
                    trailer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    serial_number = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    barcode = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    color = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    deployed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    decommissioned = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle", x => new { x.registration_no, x.tenant_id });
                    table.ForeignKey(
                        name: "fk_vehicle_asset_category_category_id",
                        column: x => x.category_id,
                        principalTable: "asset_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contact_id = table.Column<Guid>(type: "uuid", nullable: true),
                    default_role = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    account_setting_id = table.Column<Guid>(type: "uuid", nullable: true),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_users_account_setting_account_setting_id",
                        column: x => x.account_setting_id,
                        principalTable: "account_setting",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_asp_net_users_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contact",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_asp_net_users_user_role_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "lead",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contact_id = table.Column<Guid>(type: "uuid", nullable: true),
                    time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    source = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lead", x => x.id);
                    table.ForeignKey(
                        name: "fk_lead_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contact",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    address = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    approved_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    approved_by = table.Column<Guid>(type: "uuid", nullable: true),
                    type = table.Column<int>(type: "integer", nullable: true),
                    category_name = table.Column<string>(type: "text", nullable: true),
                    category_tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    geometry = table.Column<Geometry>(type: "geometry", nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_location", x => new { x.name, x.tenant_id });
                    table.ForeignKey(
                        name: "fk_location_location_category_category_name_category_tenant_id",
                        columns: x => new { x.category_name, x.category_tenant_id },
                        principalTable: "location_category",
                        principalColumns: new[] { "name", "tenant_id" });
                });

            migrationBuilder.CreateTable(
                name: "tenant",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    token = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false),
                    unique_id = table.Column<int>(type: "integer", nullable: false),
                    logo = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    profile_id = table.Column<Guid>(type: "uuid", nullable: true),
                    tenant_setting_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenant_organization_profile_id",
                        column: x => x.profile_id,
                        principalTable: "organization",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tenant_tenant_setting_tenant_setting_id",
                        column: x => x.tenant_setting_id,
                        principalTable: "tenant_setting",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "account_alert",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    account_id = table.Column<Guid>(type: "uuid", nullable: true),
                    types = table.Column<int[]>(type: "integer[]", nullable: false),
                    schedule = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_alert", x => x.id);
                    table.ForeignKey(
                        name: "fk_account_alert_asp_net_users_account_id",
                        column: x => x.account_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tag_members",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    account_id = table.Column<Guid>(type: "uuid", nullable: true),
                    expiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag_members", x => x.id);
                    table.ForeignKey(
                        name: "fk_tag_members_asp_net_users_account_id",
                        column: x => x.account_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    color = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    contact_id = table.Column<Guid>(type: "uuid", nullable: true),
                    lead_id = table.Column<Guid>(type: "uuid", nullable: true),
                    location_name = table.Column<string>(type: "character varying(256)", nullable: true),
                    location_tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    routes_name = table.Column<string>(type: "text", nullable: true),
                    routes_tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tags", x => x.id);
                    table.ForeignKey(
                        name: "fk_tags_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contact",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tags_lead_lead_id",
                        column: x => x.lead_id,
                        principalTable: "lead",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tags_location_location_name_location_tenant_id",
                        columns: x => new { x.location_name, x.location_tenant_id },
                        principalTable: "location",
                        principalColumns: new[] { "name", "tenant_id" });
                    table.ForeignKey(
                        name: "fk_tags_routes_routes_name_routes_tenant_id",
                        columns: x => new { x.routes_name, x.routes_tenant_id },
                        principalTable: "routes",
                        principalColumns: new[] { "name", "tenant_id" });
                });

            migrationBuilder.CreateTable(
                name: "tenant_branch",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    address_city = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address_country = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    address_county = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address_home_phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    address_line1 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    address_line2 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    address_phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    address_state = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address_zip = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_branch", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenant_branch_tenant_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenant",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tenant_domains",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    domain = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    registrar = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    expiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_domains", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenant_domains_tenant_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_account_alert_account_id",
                table: "account_alert",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_alert_deleted_at",
                table: "account_alert",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_account_alert_tenant_id",
                table: "account_alert",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_setting_tenant_id",
                table: "account_setting",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_roles_name",
                table: "AspNetRoles",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_account_setting_id",
                table: "AspNetUsers",
                column: "account_setting_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_contact_id",
                table: "AspNetUsers",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_role_id",
                table: "AspNetUsers",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_user_name",
                table: "AspNetUsers",
                column: "user_name");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asset_category_id",
                table: "asset",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_asset_deleted_at",
                table: "asset",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_asset_tenant_id",
                table: "asset",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_contact_deleted_at",
                table: "contact",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_contact_tenant_id",
                table: "contact",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_device_deleted_at",
                table: "device",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_device_last_update",
                table: "device",
                column: "last_update");

            migrationBuilder.CreateIndex(
                name: "ix_device_position_id",
                table: "device",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "ix_device_status",
                table: "device",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_device_tenant_id",
                table: "device",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_device_unique_id",
                table: "device",
                column: "unique_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_device_command_name",
                table: "device_command",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_lead_contact_id",
                table: "lead",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_lead_deleted_at",
                table: "lead",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_location_address",
                table: "location",
                column: "address");

            migrationBuilder.CreateIndex(
                name: "ix_location_category_id",
                table: "location",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_location_category_name_category_tenant_id",
                table: "location",
                columns: new[] { "category_name", "category_tenant_id" });

            migrationBuilder.CreateIndex(
                name: "ix_location_deleted_at",
                table: "location",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_opportunity_deleted_at",
                table: "opportunity",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_opportunity_tenant_id",
                table: "opportunity",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_organization_full_name",
                table: "organization",
                column: "full_name");

            migrationBuilder.CreateIndex(
                name: "ix_organization_name",
                table: "organization",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_routes_description",
                table: "routes",
                column: "description");

            migrationBuilder.CreateIndex(
                name: "ix_tag_members_account_id",
                table: "tag_members",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_tag_members_deleted_at",
                table: "tag_members",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_tag_members_name",
                table: "tag_members",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_tag_members_tenant_id",
                table: "tag_members",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_contact_id",
                table: "tags",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_deleted_at",
                table: "tags",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_tags_lead_id",
                table: "tags",
                column: "lead_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_location_name_location_tenant_id",
                table: "tags",
                columns: new[] { "location_name", "location_tenant_id" });

            migrationBuilder.CreateIndex(
                name: "ix_tags_name",
                table: "tags",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_tags_routes_name_routes_tenant_id",
                table: "tags",
                columns: new[] { "routes_name", "routes_tenant_id" });

            migrationBuilder.CreateIndex(
                name: "ix_tags_tenant_id",
                table: "tags",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_name",
                table: "tenant",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_profile_id",
                table: "tenant",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_tenant_setting_id",
                table: "tenant",
                column: "tenant_setting_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tenant_unique_id",
                table: "tenant",
                column: "unique_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_branch_name",
                table: "tenant_branch",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_branch_tenant_id",
                table: "tenant_branch",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_domains_deleted_at",
                table: "tenant_domains",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_domains_domain",
                table: "tenant_domains",
                column: "domain");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_domains_expiry",
                table: "tenant_domains",
                column: "expiry");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_domains_tenant_id",
                table: "tenant_domains",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_trailer_category_id",
                table: "trailer",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_trailer_deleted_at",
                table: "trailer",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_trailer_fleet_identifier",
                table: "trailer",
                column: "fleet_identifier");

            migrationBuilder.CreateIndex(
                name: "ix_trailer_serial_number",
                table: "trailer",
                column: "serial_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_trailer_tenant_id",
                table: "trailer",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_permissions_deleted_at",
                table: "user_permissions",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_user_permissions_feature",
                table: "user_permissions",
                column: "feature");

            migrationBuilder.CreateIndex(
                name: "ix_user_permissions_module",
                table: "user_permissions",
                column: "module");

            migrationBuilder.CreateIndex(
                name: "ix_user_permissions_role_id",
                table: "user_permissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_permissions_tenant_id",
                table: "user_permissions",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_category_id",
                table: "vehicle",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_deleted_at",
                table: "vehicle",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_fleet_identifier",
                table: "vehicle",
                column: "fleet_identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_tenant_id",
                table: "vehicle",
                column: "tenant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_alert");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "asset");

            migrationBuilder.DropTable(
                name: "device");

            migrationBuilder.DropTable(
                name: "device_command");

            migrationBuilder.DropTable(
                name: "opportunity");

            migrationBuilder.DropTable(
                name: "server_settings");

            migrationBuilder.DropTable(
                name: "tag_members");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "tenant_branch");

            migrationBuilder.DropTable(
                name: "tenant_domains");

            migrationBuilder.DropTable(
                name: "trailer");

            migrationBuilder.DropTable(
                name: "user_permissions");

            migrationBuilder.DropTable(
                name: "vehicle");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "lead");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "tenant");

            migrationBuilder.DropTable(
                name: "asset_category");

            migrationBuilder.DropTable(
                name: "account_setting");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "location_category");

            migrationBuilder.DropTable(
                name: "organization");

            migrationBuilder.DropTable(
                name: "tenant_setting");
        }
    }
}
