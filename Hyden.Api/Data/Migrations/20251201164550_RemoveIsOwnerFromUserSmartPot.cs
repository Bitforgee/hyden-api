using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyden.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsOwnerFromUserSmartPot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_OWNER",
                table: "USER_SMART_POTS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IS_OWNER",
                table: "USER_SMART_POTS",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
