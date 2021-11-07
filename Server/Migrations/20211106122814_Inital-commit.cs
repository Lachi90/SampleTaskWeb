using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleTaskWeb.Server.Migrations
{
    public partial class Initalcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeviceName = table.Column<string>(type: "TEXT", nullable: true),
                    FailSafe = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeviceTypeId = table.Column<string>(type: "TEXT", nullable: true),
                    TempMin = table.Column<int>(type: "INTEGER", nullable: false),
                    TempMax = table.Column<int>(type: "INTEGER", nullable: false),
                    InstallationPosition = table.Column<string>(type: "TEXT", nullable: true),
                    InsertInto19InchCabinet = table.Column<bool>(type: "INTEGER", nullable: false),
                    TerminalElement = table.Column<bool>(type: "INTEGER", nullable: true),
                    AdvancedEnvironmentConditions = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
