using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyden.Api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PLANT_SPECS",
                columns: table => new
                {
                    PLANT_SPECIFICATION_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    COMMON_NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SCIENTIFIC_NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TYPE = table.Column<int>(type: "integer", nullable: false),
                    IDEAL_TEMP_MIN = table.Column<double>(type: "double precision", nullable: false),
                    IDEAL_TEMP_MAX = table.Column<double>(type: "double precision", nullable: false),
                    LIGHT = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WATERING_FREQUENCY = table.Column<string>(type: "character varying(100)", nullable: false),
                    NOTES = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IDEAL_MOISTURE_MIN = table.Column<double>(type: "double precision", nullable: false),
                    IDEAL_MOISTURE_MAX = table.Column<double>(type: "double precision", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLANT_SPECS", x => x.PLANT_SPECIFICATION_ID);
                });

            migrationBuilder.CreateTable(
                name: "SMART_POTS",
                columns: table => new
                {
                    SMART_POT_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    QR_CODE = table.Column<string>(type: "character varying(255)", nullable: false),
                    LOCATION = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    CONNECTION_STATUS = table.Column<bool>(type: "boolean", nullable: false),
                    RESERVOIR_LEVEL = table.Column<double>(type: "double precision", nullable: false),
                    LAST_SOIL_MOISTURE = table.Column<double>(type: "double precision", nullable: false),
                    LAST_IRRIGATION = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMART_POTS", x => x.SMART_POT_ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NAME = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    EMAIL = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PASSWORD_HASH = table.Column<string>(type: "text", nullable: false),
                    EMAIL_CONFIRMED = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "IRRIGATION_HISTORIES",
                columns: table => new
                {
                    IRRIGATION_HISTORY_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    SMART_POT_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    TIMESTAMP = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WATER_AMOUNT = table.Column<double>(type: "double precision", nullable: false),
                    MOISTURE_BEFORE = table.Column<double>(type: "double precision", nullable: false),
                    MOISTURE_AFTER = table.Column<double>(type: "double precision", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IRRIGATION_HISTORIES", x => x.IRRIGATION_HISTORY_ID);
                    table.ForeignKey(
                        name: "FK_IRRIGATION_HISTORIES_SMART_POTS_SMART_POT_ID",
                        column: x => x.SMART_POT_ID,
                        principalTable: "SMART_POTS",
                        principalColumn: "SMART_POT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLANTS",
                columns: table => new
                {
                    PLANT_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NAME = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    REGISTRATION_DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SMART_POT_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    PLANT_SPECIFICATION_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLANTS", x => x.PLANT_ID);
                    table.ForeignKey(
                        name: "FK_PLANTS_PLANT_SPECS_PLANT_SPECIFICATION_ID",
                        column: x => x.PLANT_SPECIFICATION_ID,
                        principalTable: "PLANT_SPECS",
                        principalColumn: "PLANT_SPECIFICATION_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PLANTS_SMART_POTS_SMART_POT_ID",
                        column: x => x.SMART_POT_ID,
                        principalTable: "SMART_POTS",
                        principalColumn: "SMART_POT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_NOTIFICATIONS",
                columns: table => new
                {
                    USER_NOTIFICATION_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    USER_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    IS_READ = table.Column<bool>(type: "boolean", nullable: false),
                    TITLE = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    MESSAGE = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TYPE = table.Column<int>(type: "integer", nullable: false),
                    SENT_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    STATUS = table.Column<int>(type: "integer", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_NOTIFICATIONS", x => x.USER_NOTIFICATION_ID);
                    table.ForeignKey(
                        name: "FK_USER_NOTIFICATIONS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IRRIGATION_HISTORIES_SMART_POT_ID",
                table: "IRRIGATION_HISTORIES",
                column: "SMART_POT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PLANTS_PLANT_SPECIFICATION_ID",
                table: "PLANTS",
                column: "PLANT_SPECIFICATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PLANTS_SMART_POT_ID",
                table: "PLANTS",
                column: "SMART_POT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SMART_POTS_QR_CODE",
                table: "SMART_POTS",
                column: "QR_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_NOTIFICATIONS_USER_ID",
                table: "USER_NOTIFICATIONS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_EMAIL",
                table: "USERS",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IRRIGATION_HISTORIES");

            migrationBuilder.DropTable(
                name: "PLANTS");

            migrationBuilder.DropTable(
                name: "USER_NOTIFICATIONS");

            migrationBuilder.DropTable(
                name: "PLANT_SPECS");

            migrationBuilder.DropTable(
                name: "SMART_POTS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
