using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comrade.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airp_airplane",
                columns: table => new
                {
                    airp_uuid_airplane = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    airp_tx_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    airp_tx_model = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    airp_qt_passenger = table.Column<int>(type: "int", nullable: false),
                    airp_dt_register = table.Column<string>(type: "varchar(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_airp_airplane", x => x.airp_uuid_airplane);
                });

            migrationBuilder.CreateTable(
                name: "fiin_financial_information",
                columns: table => new
                {
                    fiin_uuid_financial_information = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fiin_nb_type = table.Column<string>(type: "varchar", nullable: false),
                    fiin_dt_dateTime = table.Column<DateTime>(type: "dateTime", nullable: false),
                    fiin_dc_value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    fiin_tx_cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    fiin_tx_card = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    fiin_tx_shop = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    fiin_tx_store = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fiin_financial_information", x => x.fiin_uuid_financial_information);
                });

            migrationBuilder.CreateTable(
                name: "sype_system_permission",
                columns: table => new
                {
                    sype_uuid_system_permission = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sype_tx_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    sype_tx_tag = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sype_system_permission", x => x.sype_uuid_system_permission);
                });

            migrationBuilder.CreateTable(
                name: "syro_system_role",
                columns: table => new
                {
                    syro_uuid_system_role = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    syro_tx_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_syro_system_role", x => x.syro_uuid_system_role);
                });

            migrationBuilder.CreateTable(
                name: "syus_system_user",
                columns: table => new
                {
                    syus_uuid_system_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    syus_tx_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    syus_tx_email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    syus_pw_password = table.Column<string>(type: "varchar(1023)", maxLength: 1023, nullable: false),
                    syus_tx_registration = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    syus_dt_register = table.Column<string>(type: "varchar(48)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_syus_system_user", x => x.syus_uuid_system_user);
                });

            migrationBuilder.CreateTable(
                name: "sype_system_permission_syro_system_role",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemPermissionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sype_system_permission_syro_system_role", x => new { x.RolesId, x.SystemPermissionsId });
                    table.ForeignKey(
                        name: "FK_sype_system_permission_syro_system_role_sype_system_permission_SystemPermissionsId",
                        column: x => x.SystemPermissionsId,
                        principalTable: "sype_system_permission",
                        principalColumn: "sype_uuid_system_permission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sype_system_permission_syro_system_role_syro_system_role_RolesId",
                        column: x => x.RolesId,
                        principalTable: "syro_system_role",
                        principalColumn: "syro_uuid_system_role",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "syus_system_user_sype_system_permission",
                columns: table => new
                {
                    SystemPermissionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_syus_system_user_sype_system_permission", x => new { x.SystemPermissionsId, x.SystemUsersId });
                    table.ForeignKey(
                        name: "FK_syus_system_user_sype_system_permission_sype_system_permission_SystemPermissionsId",
                        column: x => x.SystemPermissionsId,
                        principalTable: "sype_system_permission",
                        principalColumn: "sype_uuid_system_permission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_syus_system_user_sype_system_permission_syus_system_user_SystemUsersId",
                        column: x => x.SystemUsersId,
                        principalTable: "syus_system_user",
                        principalColumn: "syus_uuid_system_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "syus_system_user_syro_system_role",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_syus_system_user_syro_system_role", x => new { x.RolesId, x.SystemUsersId });
                    table.ForeignKey(
                        name: "FK_syus_system_user_syro_system_role_syro_system_role_RolesId",
                        column: x => x.RolesId,
                        principalTable: "syro_system_role",
                        principalColumn: "syro_uuid_system_role",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_syus_system_user_syro_system_role_syus_system_user_SystemUsersId",
                        column: x => x.SystemUsersId,
                        principalTable: "syus_system_user",
                        principalColumn: "syus_uuid_system_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_un_airp_tx_code",
                table: "airp_airplane",
                column: "airp_tx_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sype_system_permission_syro_system_role_SystemPermissionsId",
                table: "sype_system_permission_syro_system_role",
                column: "SystemPermissionsId");

            migrationBuilder.CreateIndex(
                name: "ix_un_syus_tx_email",
                table: "syus_system_user",
                column: "syus_tx_email",
                unique: true,
                filter: "[syus_tx_email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_un_syus_tx_registration",
                table: "syus_system_user",
                column: "syus_tx_registration",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_syus_system_user_sype_system_permission_SystemUsersId",
                table: "syus_system_user_sype_system_permission",
                column: "SystemUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_syus_system_user_syro_system_role_SystemUsersId",
                table: "syus_system_user_syro_system_role",
                column: "SystemUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "airp_airplane");

            migrationBuilder.DropTable(
                name: "fiin_financial_information");

            migrationBuilder.DropTable(
                name: "sype_system_permission_syro_system_role");

            migrationBuilder.DropTable(
                name: "syus_system_user_sype_system_permission");

            migrationBuilder.DropTable(
                name: "syus_system_user_syro_system_role");

            migrationBuilder.DropTable(
                name: "sype_system_permission");

            migrationBuilder.DropTable(
                name: "syro_system_role");

            migrationBuilder.DropTable(
                name: "syus_system_user");
        }
    }
}
