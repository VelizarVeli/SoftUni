using Microsoft.EntityFrameworkCore.Migrations;

namespace EventuresWebApp.Data.Migrations
{
    public partial class TicketsLeftAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketsLeft",
                table: "Events",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketsLeft",
                table: "Events");
        }
    }
}
