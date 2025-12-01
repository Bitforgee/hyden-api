using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyden.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSmartPotRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER_SMART_POTS",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    SMART_POT_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    IS_OWNER = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    ASSIGNED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_SMART_POTS", x => new { x.USER_ID, x.SMART_POT_ID });
                    table.ForeignKey(
                        name: "FK_USER_SMART_POTS_SMART_POTS_SMART_POT_ID",
                        column: x => x.SMART_POT_ID,
                        principalTable: "SMART_POTS",
                        principalColumn: "SMART_POT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_SMART_POTS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USER_SMART_POTS_SMART_POT_ID",
                table: "USER_SMART_POTS",
                column: "SMART_POT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_SMART_POTS_USER_ID",
                table: "USER_SMART_POTS",
                column: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER_SMART_POTS");
        }
    }
}
