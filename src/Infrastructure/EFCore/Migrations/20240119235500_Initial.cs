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
                name: "asset_categories",
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
                    table.PrimaryKey("pk_asset_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "device_commands",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    delay = table.Column<int>(type: "integer", nullable: false),
                    messages = table.Column<string>(type: "text", nullable: false),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_commands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "location_categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_location_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "opportunities",
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
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_opportunities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
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
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_routes", x => x.id);
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
                name: "tags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    color = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tags", x => x.id);
                    table.ForeignKey(
                        name: "fk_tags_tags_parent_id",
                        column: x => x.parent_id,
                        principalTable: "tags",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tenants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    token = table.Column<Guid>(type: "uuid", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    logo = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenants", x => x.id);
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
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true)
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
                name: "assets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    serial_number = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    barcode = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    color = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    deployed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    decommissioned = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assets", x => x.id);
                    table.ForeignKey(
                        name: "fk_assets_asset_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "asset_categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    unique_id = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    last_update = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_moved = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    speed_limit = table.Column<int>(type: "integer", nullable: false),
                    expiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    barcode = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    color = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    deployed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    decommissioned = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_devices", x => x.id);
                    table.ForeignKey(
                        name: "fk_devices_asset_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "asset_categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "trailers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false),
                    fleet_identifier = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    unique_id = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
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
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    barcode = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    color = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    deployed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    decommissioned = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trailers", x => x.id);
                    table.ForeignKey(
                        name: "fk_trailers_asset_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "asset_categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    address = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    approved_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    approved_by = table.Column<Guid>(type: "uuid", nullable: true),
                    type = table.Column<int>(type: "integer", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    geometry = table.Column<Geometry>(type: "geometry", nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_locations", x => x.id);
                    table.ForeignKey(
                        name: "fk_locations_location_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "location_categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "route_tag",
                columns: table => new
                {
                    route_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_route_tag", x => new { x.route_id, x.tag_id });
                    table.ForeignKey(
                        name: "fk_route_tag_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_route_tag_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    relation_type = table.Column<int>(type: "integer", nullable: false),
                    full_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    job_position = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    mobile = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    website = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    married = table.Column<bool>(type: "boolean", nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    notes = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    company_id = table.Column<Guid>(type: "uuid", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contacts", x => x.id);
                    table.ForeignKey(
                        name: "fk_contacts_contacts_company_id",
                        column: x => x.company_id,
                        principalTable: "contacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_contacts_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
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
                    expiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_domains", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenant_domains_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tenant_settings",
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
                    table.PrimaryKey("pk_tenant_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenant_settings_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "trailer_tag",
                columns: table => new
                {
                    trailer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trailer_tag", x => new { x.tag_id, x.trailer_id });
                    table.ForeignKey(
                        name: "fk_trailer_tag_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trailer_tag_trailers_trailer_id",
                        column: x => x.trailer_id,
                        principalTable: "trailers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    fleet_identifier = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    registration_no = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    odometer = table.Column<long>(type: "bigint", nullable: false),
                    fuel_type = table.Column<int>(type: "integer", nullable: false),
                    fuel_capacity = table.Column<int>(type: "integer", nullable: false),
                    horse_power = table.Column<int>(type: "integer", nullable: false),
                    model = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    weight_capacity = table.Column<decimal>(type: "numeric", nullable: false),
                    trailer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    device_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    barcode = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    color = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    deployed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    decommissioned = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicles_asset_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "asset_categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vehicles_devices_device_id",
                        column: x => x.device_id,
                        principalTable: "devices",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vehicles_trailers_trailer_id",
                        column: x => x.trailer_id,
                        principalTable: "trailers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "location_tag",
                columns: table => new
                {
                    location_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_location_tag", x => new { x.location_id, x.tag_id });
                    table.ForeignKey(
                        name: "fk_location_tag_locations_location_id",
                        column: x => x.location_id,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_location_tag_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    line1 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    line2 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    city = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    county = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    state = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    zip = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    home_phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    contact_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_addresses", x => x.id);
                    table.ForeignKey(
                        name: "fk_addresses_contacts_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contacts",
                        principalColumn: "id");
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
                        name: "fk_asp_net_users_contacts_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_asp_net_users_user_role_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "contact_tag",
                columns: table => new
                {
                    contact_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contact_tag", x => new { x.contact_id, x.tag_id });
                    table.ForeignKey(
                        name: "fk_contact_tag_contacts_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_contact_tag_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "leads",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contact_id = table.Column<Guid>(type: "uuid", nullable: true),
                    time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    source = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_leads", x => x.id);
                    table.ForeignKey(
                        name: "fk_leads_contacts_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contacts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vehicle_tag",
                columns: table => new
                {
                    vehicle_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle_tag", x => new { x.tag_id, x.vehicle_id });
                    table.ForeignKey(
                        name: "fk_vehicle_tag_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicle_tag_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account_alerts",
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
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_alerts", x => x.id);
                    table.ForeignKey(
                        name: "fk_account_alerts_user_account_account_id",
                        column: x => x.account_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "account_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_account_id = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("pk_account_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_account_settings_user_account_user_account_id",
                        column: x => x.user_account_id,
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
                    tag_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    account_id = table.Column<Guid>(type: "uuid", nullable: true),
                    expiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag_members", x => x.id);
                    table.ForeignKey(
                        name: "fk_tag_members_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tag_members_user_account_account_id",
                        column: x => x.account_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "lead_tag",
                columns: table => new
                {
                    lead_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lead_tag", x => new { x.lead_id, x.tag_id });
                    table.ForeignKey(
                        name: "fk_lead_tag_leads_lead_id",
                        column: x => x.lead_id,
                        principalTable: "leads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lead_tag_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_account_alerts_account_id",
                table: "account_alerts",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_alerts_deleted_at",
                table: "account_alerts",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_account_alerts_tenant_id",
                table: "account_alerts",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_settings_tenant_id",
                table: "account_settings",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_settings_user_account_id",
                table: "account_settings",
                column: "user_account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_addresses_contact_id",
                table: "addresses",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_addresses_deleted_at",
                table: "addresses",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_addresses_tenant_id",
                table: "addresses",
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
                name: "ix_asp_net_users_contact_id",
                table: "AspNetUsers",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_role_id",
                table: "AspNetUsers",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_tenant_id_email",
                table: "AspNetUsers",
                columns: new[] { "tenant_id", "email" },
                unique: true);

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
                name: "ix_assets_category_id",
                table: "assets",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_assets_deleted_at",
                table: "assets",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_assets_serial_number_tenant_id",
                table: "assets",
                columns: new[] { "serial_number", "tenant_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_assets_tenant_id",
                table: "assets",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_contact_tag_contact_id_tag_id",
                table: "contact_tag",
                columns: new[] { "contact_id", "tag_id" });

            migrationBuilder.CreateIndex(
                name: "ix_contact_tag_tag_id",
                table: "contact_tag",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_contacts_company_id",
                table: "contacts",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_contacts_deleted_at",
                table: "contacts",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_contacts_tenant_id",
                table: "contacts",
                column: "tenant_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_contacts_tenant_id_email",
                table: "contacts",
                columns: new[] { "tenant_id", "email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_device_commands_name",
                table: "device_commands",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_devices_category_id",
                table: "devices",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_devices_deleted_at",
                table: "devices",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_devices_last_update",
                table: "devices",
                column: "last_update");

            migrationBuilder.CreateIndex(
                name: "ix_devices_position_id",
                table: "devices",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "ix_devices_status",
                table: "devices",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_devices_tenant_id",
                table: "devices",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_devices_unique_id",
                table: "devices",
                column: "unique_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_lead_tag_tag_id",
                table: "lead_tag",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_leads_contact_id",
                table: "leads",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_leads_deleted_at",
                table: "leads",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_location_categories_name_tenant_id",
                table: "location_categories",
                columns: new[] { "name", "tenant_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_location_tag_tag_id",
                table: "location_tag",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_locations_address",
                table: "locations",
                column: "address");

            migrationBuilder.CreateIndex(
                name: "ix_locations_category_id",
                table: "locations",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_locations_deleted_at",
                table: "locations",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_locations_name_tenant_id",
                table: "locations",
                columns: new[] { "name", "tenant_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_opportunities_deleted_at",
                table: "opportunities",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_opportunities_tenant_id",
                table: "opportunities",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_route_tag_tag_id",
                table: "route_tag",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_routes_description",
                table: "routes",
                column: "description");

            migrationBuilder.CreateIndex(
                name: "ix_routes_name_tenant_id",
                table: "routes",
                columns: new[] { "name", "tenant_id" },
                unique: true);

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
                name: "ix_tag_members_tag_id",
                table: "tag_members",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_tag_members_tenant_id",
                table: "tag_members",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_deleted_at",
                table: "tags",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_tags_name",
                table: "tags",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_tags_parent_id",
                table: "tags",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_tenant_id",
                table: "tags",
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
                name: "ix_tenant_settings_tenant_id",
                table: "tenant_settings",
                column: "tenant_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tenants_name",
                table: "tenants",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_trailer_tag_trailer_id",
                table: "trailer_tag",
                column: "trailer_id");

            migrationBuilder.CreateIndex(
                name: "ix_trailers_category_id",
                table: "trailers",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_trailers_deleted_at",
                table: "trailers",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_trailers_fleet_identifier_tenant_id",
                table: "trailers",
                columns: new[] { "fleet_identifier", "tenant_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_trailers_name_tenant_id",
                table: "trailers",
                columns: new[] { "name", "tenant_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_trailers_tenant_id",
                table: "trailers",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_trailers_unique_id",
                table: "trailers",
                column: "unique_id",
                unique: true);

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
                name: "ix_vehicle_tag_vehicle_id",
                table: "vehicle_tag",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_category_id",
                table: "vehicles",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_deleted_at",
                table: "vehicles",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_device_id",
                table: "vehicles",
                column: "device_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_fleet_identifier_tenant_id",
                table: "vehicles",
                columns: new[] { "fleet_identifier", "tenant_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_registration_no_tenant_id",
                table: "vehicles",
                columns: new[] { "registration_no", "tenant_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_tenant_id",
                table: "vehicles",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_trailer_id",
                table: "vehicles",
                column: "trailer_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_alerts");

            migrationBuilder.DropTable(
                name: "account_settings");

            migrationBuilder.DropTable(
                name: "addresses");

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
                name: "assets");

            migrationBuilder.DropTable(
                name: "contact_tag");

            migrationBuilder.DropTable(
                name: "device_commands");

            migrationBuilder.DropTable(
                name: "lead_tag");

            migrationBuilder.DropTable(
                name: "location_tag");

            migrationBuilder.DropTable(
                name: "opportunities");

            migrationBuilder.DropTable(
                name: "route_tag");

            migrationBuilder.DropTable(
                name: "server_settings");

            migrationBuilder.DropTable(
                name: "tag_members");

            migrationBuilder.DropTable(
                name: "tenant_domains");

            migrationBuilder.DropTable(
                name: "tenant_settings");

            migrationBuilder.DropTable(
                name: "trailer_tag");

            migrationBuilder.DropTable(
                name: "user_permissions");

            migrationBuilder.DropTable(
                name: "vehicle_tag");

            migrationBuilder.DropTable(
                name: "leads");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "location_categories");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "trailers");

            migrationBuilder.DropTable(
                name: "tenants");

            migrationBuilder.DropTable(
                name: "asset_categories");
        }
    }
}
