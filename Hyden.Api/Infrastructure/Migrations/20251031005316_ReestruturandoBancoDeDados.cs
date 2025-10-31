using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyden.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReestruturandoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IrrigationHistories_SmartPots_SmartPotId",
                table: "IrrigationHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_PlantSpecs_PlantSpecificationId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_SmartPots_SmartPotId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Users_UserId",
                table: "UserNotifications");

            migrationBuilder.DropTable(
                name: "PlantSpecs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plants",
                table: "Plants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNotifications",
                table: "UserNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmartPots",
                table: "SmartPots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IrrigationHistories",
                table: "IrrigationHistories");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "USERS");

            migrationBuilder.RenameTable(
                name: "Plants",
                newName: "PLANTS");

            migrationBuilder.RenameTable(
                name: "UserNotifications",
                newName: "USER_NOTIFICATIONS");

            migrationBuilder.RenameTable(
                name: "SmartPots",
                newName: "SMART_POTS");

            migrationBuilder.RenameTable(
                name: "IrrigationHistories",
                newName: "IRRIGATION_HISTORIES");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "USERS",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "USERS",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "USERS",
                newName: "PASSWORD_HASH");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "USERS",
                newName: "EMAIL_CONFIRMED");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "USERS",
                newName: "USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "USERS",
                newName: "IX_USERS_EMAIL");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PLANTS",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "SmartPotId",
                table: "PLANTS",
                newName: "SMART_POT_ID");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "PLANTS",
                newName: "REGISTRATION_DATE");

            migrationBuilder.RenameColumn(
                name: "PlantSpecificationId",
                table: "PLANTS",
                newName: "PLANT_SPECIFICATION_ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PLANTS",
                newName: "PLANT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_SmartPotId",
                table: "PLANTS",
                newName: "IX_PLANTS_SMART_POT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_PlantSpecificationId",
                table: "PLANTS",
                newName: "IX_PLANTS_PLANT_SPECIFICATION_ID");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "USER_NOTIFICATIONS",
                newName: "TYPE");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "USER_NOTIFICATIONS",
                newName: "TITLE");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "USER_NOTIFICATIONS",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "USER_NOTIFICATIONS",
                newName: "MESSAGE");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "USER_NOTIFICATIONS",
                newName: "USER_ID");

            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "USER_NOTIFICATIONS",
                newName: "SENT_AT");

            migrationBuilder.RenameColumn(
                name: "IsRead",
                table: "USER_NOTIFICATIONS",
                newName: "IS_READ");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "USER_NOTIFICATIONS",
                newName: "USER_NOTIFICATION_ID");

            migrationBuilder.RenameIndex(
                name: "IX_UserNotifications_UserId",
                table: "USER_NOTIFICATIONS",
                newName: "IX_USER_NOTIFICATIONS_USER_ID");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "SMART_POTS",
                newName: "LOCATION");

            migrationBuilder.RenameColumn(
                name: "ReservoirLevel",
                table: "SMART_POTS",
                newName: "RESERVOIR_LEVEL");

            migrationBuilder.RenameColumn(
                name: "QrCode",
                table: "SMART_POTS",
                newName: "QR_CODE");

            migrationBuilder.RenameColumn(
                name: "LastSoilMoisture",
                table: "SMART_POTS",
                newName: "LAST_SOIL_MOISTURE");

            migrationBuilder.RenameColumn(
                name: "LastIrrigation",
                table: "SMART_POTS",
                newName: "LAST_IRRIGATION");

            migrationBuilder.RenameColumn(
                name: "ConnectionStatus",
                table: "SMART_POTS",
                newName: "CONNECTION_STATUS");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SMART_POTS",
                newName: "SMART_POT_ID");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "IRRIGATION_HISTORIES",
                newName: "TIMESTAMP");

            migrationBuilder.RenameColumn(
                name: "WaterAmount",
                table: "IRRIGATION_HISTORIES",
                newName: "WATER_AMOUNT");

            migrationBuilder.RenameColumn(
                name: "SmartPotId",
                table: "IRRIGATION_HISTORIES",
                newName: "SMART_POT_ID");

            migrationBuilder.RenameColumn(
                name: "MoistureBefore",
                table: "IRRIGATION_HISTORIES",
                newName: "MOISTURE_BEFORE");

            migrationBuilder.RenameColumn(
                name: "MoistureAfter",
                table: "IRRIGATION_HISTORIES",
                newName: "MOISTURE_AFTER");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "IRRIGATION_HISTORIES",
                newName: "IRRIGATION_HISTORY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_IrrigationHistories_SmartPotId",
                table: "IRRIGATION_HISTORIES",
                newName: "IX_IRRIGATION_HISTORIES_SMART_POT_ID");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "USERS",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "USERS",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORD_HASH",
                table: "USERS",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EMAIL_CONFIRMED",
                table: "USERS",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "USERS",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_AT",
                table: "USERS",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "PLANTS",
                type: "character varying(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "PLANTS",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_AT",
                table: "PLANTS",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                table: "USER_NOTIFICATIONS",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MESSAGE",
                table: "USER_NOTIFICATIONS",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "USER_NOTIFICATIONS",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_AT",
                table: "USER_NOTIFICATIONS",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "LOCATION",
                table: "SMART_POTS",
                type: "character varying(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QR_CODE",
                table: "SMART_POTS",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "SMART_POTS",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_AT",
                table: "SMART_POTS",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "IRRIGATION_HISTORIES",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_AT",
                table: "IRRIGATION_HISTORIES",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_USERS",
                table: "USERS",
                column: "USER_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PLANTS",
                table: "PLANTS",
                column: "PLANT_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER_NOTIFICATIONS",
                table: "USER_NOTIFICATIONS",
                column: "USER_NOTIFICATION_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SMART_POTS",
                table: "SMART_POTS",
                column: "SMART_POT_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IRRIGATION_HISTORIES",
                table: "IRRIGATION_HISTORIES",
                column: "IRRIGATION_HISTORY_ID");

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
                    WATERING_FREQUENCY = table.Column<string>(type: "text", nullable: false),
                    NOTES = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IDEAL_MOISTURE_MIN = table.Column<double>(type: "double precision", nullable: false),
                    IDEAL_MOISTURE_MAX = table.Column<double>(type: "double precision", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLANT_SPECS", x => x.PLANT_SPECIFICATION_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SMART_POTS_QR_CODE",
                table: "SMART_POTS",
                column: "QR_CODE",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IRRIGATION_HISTORIES_SMART_POTS_SMART_POT_ID",
                table: "IRRIGATION_HISTORIES",
                column: "SMART_POT_ID",
                principalTable: "SMART_POTS",
                principalColumn: "SMART_POT_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PLANTS_PLANT_SPECS_PLANT_SPECIFICATION_ID",
                table: "PLANTS",
                column: "PLANT_SPECIFICATION_ID",
                principalTable: "PLANT_SPECS",
                principalColumn: "PLANT_SPECIFICATION_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PLANTS_SMART_POTS_SMART_POT_ID",
                table: "PLANTS",
                column: "SMART_POT_ID",
                principalTable: "SMART_POTS",
                principalColumn: "SMART_POT_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_NOTIFICATIONS_USERS_USER_ID",
                table: "USER_NOTIFICATIONS",
                column: "USER_ID",
                principalTable: "USERS",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IRRIGATION_HISTORIES_SMART_POTS_SMART_POT_ID",
                table: "IRRIGATION_HISTORIES");

            migrationBuilder.DropForeignKey(
                name: "FK_PLANTS_PLANT_SPECS_PLANT_SPECIFICATION_ID",
                table: "PLANTS");

            migrationBuilder.DropForeignKey(
                name: "FK_PLANTS_SMART_POTS_SMART_POT_ID",
                table: "PLANTS");

            migrationBuilder.DropForeignKey(
                name: "FK_USER_NOTIFICATIONS_USERS_USER_ID",
                table: "USER_NOTIFICATIONS");

            migrationBuilder.DropTable(
                name: "PLANT_SPECS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USERS",
                table: "USERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PLANTS",
                table: "PLANTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USER_NOTIFICATIONS",
                table: "USER_NOTIFICATIONS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SMART_POTS",
                table: "SMART_POTS");

            migrationBuilder.DropIndex(
                name: "IX_SMART_POTS_QR_CODE",
                table: "SMART_POTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IRRIGATION_HISTORIES",
                table: "IRRIGATION_HISTORIES");

            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "UPDATED_AT",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "PLANTS");

            migrationBuilder.DropColumn(
                name: "UPDATED_AT",
                table: "PLANTS");

            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "USER_NOTIFICATIONS");

            migrationBuilder.DropColumn(
                name: "UPDATED_AT",
                table: "USER_NOTIFICATIONS");

            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "SMART_POTS");

            migrationBuilder.DropColumn(
                name: "UPDATED_AT",
                table: "SMART_POTS");

            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "IRRIGATION_HISTORIES");

            migrationBuilder.DropColumn(
                name: "UPDATED_AT",
                table: "IRRIGATION_HISTORIES");

            migrationBuilder.RenameTable(
                name: "USERS",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "PLANTS",
                newName: "Plants");

            migrationBuilder.RenameTable(
                name: "USER_NOTIFICATIONS",
                newName: "UserNotifications");

            migrationBuilder.RenameTable(
                name: "SMART_POTS",
                newName: "SmartPots");

            migrationBuilder.RenameTable(
                name: "IRRIGATION_HISTORIES",
                newName: "IrrigationHistories");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "PASSWORD_HASH",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "EMAIL_CONFIRMED",
                table: "Users",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_USERS_EMAIL",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Plants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SMART_POT_ID",
                table: "Plants",
                newName: "SmartPotId");

            migrationBuilder.RenameColumn(
                name: "REGISTRATION_DATE",
                table: "Plants",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "PLANT_SPECIFICATION_ID",
                table: "Plants",
                newName: "PlantSpecificationId");

            migrationBuilder.RenameColumn(
                name: "PLANT_ID",
                table: "Plants",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_PLANTS_SMART_POT_ID",
                table: "Plants",
                newName: "IX_Plants_SmartPotId");

            migrationBuilder.RenameIndex(
                name: "IX_PLANTS_PLANT_SPECIFICATION_ID",
                table: "Plants",
                newName: "IX_Plants_PlantSpecificationId");

            migrationBuilder.RenameColumn(
                name: "TYPE",
                table: "UserNotifications",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "TITLE",
                table: "UserNotifications",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "UserNotifications",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "MESSAGE",
                table: "UserNotifications",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "UserNotifications",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SENT_AT",
                table: "UserNotifications",
                newName: "SentAt");

            migrationBuilder.RenameColumn(
                name: "IS_READ",
                table: "UserNotifications",
                newName: "IsRead");

            migrationBuilder.RenameColumn(
                name: "USER_NOTIFICATION_ID",
                table: "UserNotifications",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_USER_NOTIFICATIONS_USER_ID",
                table: "UserNotifications",
                newName: "IX_UserNotifications_UserId");

            migrationBuilder.RenameColumn(
                name: "LOCATION",
                table: "SmartPots",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "RESERVOIR_LEVEL",
                table: "SmartPots",
                newName: "ReservoirLevel");

            migrationBuilder.RenameColumn(
                name: "QR_CODE",
                table: "SmartPots",
                newName: "QrCode");

            migrationBuilder.RenameColumn(
                name: "LAST_SOIL_MOISTURE",
                table: "SmartPots",
                newName: "LastSoilMoisture");

            migrationBuilder.RenameColumn(
                name: "LAST_IRRIGATION",
                table: "SmartPots",
                newName: "LastIrrigation");

            migrationBuilder.RenameColumn(
                name: "CONNECTION_STATUS",
                table: "SmartPots",
                newName: "ConnectionStatus");

            migrationBuilder.RenameColumn(
                name: "SMART_POT_ID",
                table: "SmartPots",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TIMESTAMP",
                table: "IrrigationHistories",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "WATER_AMOUNT",
                table: "IrrigationHistories",
                newName: "WaterAmount");

            migrationBuilder.RenameColumn(
                name: "SMART_POT_ID",
                table: "IrrigationHistories",
                newName: "SmartPotId");

            migrationBuilder.RenameColumn(
                name: "MOISTURE_BEFORE",
                table: "IrrigationHistories",
                newName: "MoistureBefore");

            migrationBuilder.RenameColumn(
                name: "MOISTURE_AFTER",
                table: "IrrigationHistories",
                newName: "MoistureAfter");

            migrationBuilder.RenameColumn(
                name: "IRRIGATION_HISTORY_ID",
                table: "IrrigationHistories",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_IRRIGATION_HISTORIES_SMART_POT_ID",
                table: "IrrigationHistories",
                newName: "IX_IrrigationHistories_SmartPotId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "EmailConfirmed",
                table: "Users",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Plants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "UserNotifications",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "UserNotifications",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "SmartPots",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "QrCode",
                table: "SmartPots",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plants",
                table: "Plants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNotifications",
                table: "UserNotifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmartPots",
                table: "SmartPots",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IrrigationHistories",
                table: "IrrigationHistories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlantSpecs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CommonName = table.Column<string>(type: "text", nullable: true),
                    IdealMoistureMax = table.Column<double>(type: "double precision", nullable: false),
                    IdealMoistureMin = table.Column<double>(type: "double precision", nullable: false),
                    IdealTempMax = table.Column<double>(type: "double precision", nullable: false),
                    IdealTempMin = table.Column<double>(type: "double precision", nullable: false),
                    Light = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ScientificName = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    WateringFrequency = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantSpecs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_IrrigationHistories_SmartPots_SmartPotId",
                table: "IrrigationHistories",
                column: "SmartPotId",
                principalTable: "SmartPots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_PlantSpecs_PlantSpecificationId",
                table: "Plants",
                column: "PlantSpecificationId",
                principalTable: "PlantSpecs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_SmartPots_SmartPotId",
                table: "Plants",
                column: "SmartPotId",
                principalTable: "SmartPots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Users_UserId",
                table: "UserNotifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
