using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyden.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSerialNumberToSmartPot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SERIAL_NUMBER",
                table: "SMART_POTS",
                type: "character varying(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SERIAL_NUMBER",
                table: "SMART_POTS");
        }
    }
}
