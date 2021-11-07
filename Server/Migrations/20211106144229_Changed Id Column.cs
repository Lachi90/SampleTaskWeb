using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleTaskWeb.Server.Migrations
{
    public partial class ChangedIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Devices",
                newName: "InternalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InternalId",
                table: "Devices",
                newName: "Id");
        }
    }
}
