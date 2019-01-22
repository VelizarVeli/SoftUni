using Microsoft.EntityFrameworkCore.Migrations;

namespace FDMCBook.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.RenameTable(
                name: "Responses",
                newName: "Cats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cats",
                table: "Cats",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cats",
                table: "Cats");

            migrationBuilder.RenameTable(
                name: "Cats",
                newName: "Responses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "Id");
        }
    }
}
