using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyden.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTableVerificationCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VERIFICATION_CODES",
                columns: table => new
                {
                    EMAIL = table.Column<string>(type: "character varying(255)", nullable: false),
                    PURPOSE = table.Column<string>(type: "character varying(30)", nullable: false),
                    CODE = table.Column<string>(type: "character varying(12)", nullable: false),
                    EXPIRES_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VERIFICATION_CODES", x => new { x.EMAIL, x.PURPOSE });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VERIFICATION_CODES");
        }
    }
}
