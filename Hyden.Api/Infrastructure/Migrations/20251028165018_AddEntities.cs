using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyden.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantSpecs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CommonName = table.Column<string>(type: "text", nullable: true),
                    ScientificName = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    IdealTempMin = table.Column<double>(type: "double precision", nullable: false),
                    IdealTempMax = table.Column<double>(type: "double precision", nullable: false),
                    Light = table.Column<string>(type: "text", nullable: true),
                    WateringFrequency = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    IdealMoistureMin = table.Column<double>(type: "double precision", nullable: false),
                    IdealMoistureMax = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantSpecs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmartPots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QrCode = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    ConnectionStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ReservoirLevel = table.Column<double>(type: "double precision", nullable: false),
                    LastSoilMoisture = table.Column<double>(type: "double precision", nullable: false),
                    LastIrrigation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartPots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IrrigationHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SmartPotId = table.Column<Guid>(type: "uuid", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WaterAmount = table.Column<double>(type: "double precision", nullable: false),
                    MoistureBefore = table.Column<double>(type: "double precision", nullable: false),
                    MoistureAfter = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IrrigationHistories_SmartPots_SmartPotId",
                        column: x => x.SmartPotId,
                        principalTable: "SmartPots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SmartPotId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlantSpecificationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_PlantSpecs_PlantSpecificationId",
                        column: x => x.PlantSpecificationId,
                        principalTable: "PlantSpecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_SmartPots_SmartPotId",
                        column: x => x.SmartPotId,
                        principalTable: "SmartPots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationHistories_SmartPotId",
                table: "IrrigationHistories",
                column: "SmartPotId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PlantSpecificationId",
                table: "Plants",
                column: "PlantSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_SmartPotId",
                table: "Plants",
                column: "SmartPotId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserId",
                table: "UserNotifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IrrigationHistories");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "PlantSpecs");

            migrationBuilder.DropTable(
                name: "SmartPots");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
