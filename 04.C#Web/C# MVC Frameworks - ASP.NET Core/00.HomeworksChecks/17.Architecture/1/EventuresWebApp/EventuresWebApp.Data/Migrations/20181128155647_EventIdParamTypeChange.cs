using Microsoft.EntityFrameworkCore.Migrations;

namespace EventuresWebApp.Data.Migrations
{
    public partial class EventIdParamTypeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Events_EventId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_EventId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EventId",
                table: "Orders",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Events_EventId",
                table: "Orders",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Events_EventId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_EventId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventId1",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EventId1",
                table: "Orders",
                column: "EventId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Events_EventId1",
                table: "Orders",
                column: "EventId1",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
