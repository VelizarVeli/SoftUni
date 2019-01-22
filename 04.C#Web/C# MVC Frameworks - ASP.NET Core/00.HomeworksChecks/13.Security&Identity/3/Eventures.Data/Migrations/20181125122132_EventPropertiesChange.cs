using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventures.Web.Data.Migrations
{
    public partial class EventPropertiesChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UCN",
                table: "AspNetUsers",
                newName: "Ucn");

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Ucn",
                table: "AspNetUsers",
                newName: "UCN");
        }
    }
}
