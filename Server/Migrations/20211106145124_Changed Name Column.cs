using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleTaskWeb.Server.Migrations
{
    public partial class ChangedNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeviceName",
                table: "Devices",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Devices",
                newName: "DeviceName");
        }
    }
}
