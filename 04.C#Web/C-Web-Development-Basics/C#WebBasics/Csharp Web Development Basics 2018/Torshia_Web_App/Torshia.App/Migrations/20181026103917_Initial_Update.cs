using Microsoft.EntityFrameworkCore.Migrations;

namespace Torshia.App.Migrations
{
    public partial class Initial_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Task_TaskId",
                table: "Participant");

            migrationBuilder.DropTable(
                name: "TaskSectors");

            migrationBuilder.DropIndex(
                name: "IX_Participant_TaskId",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Participant");

            migrationBuilder.CreateTable(
                name: "TaskParticitpant",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    ParticipantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskParticitpant", x => new { x.TaskId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_TaskParticitpant_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskParticitpant_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskSector",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    SectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSector", x => new { x.TaskId, x.SectorId });
                    table.ForeignKey(
                        name: "FK_TaskSector_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskSector_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskParticitpant_ParticipantId",
                table: "TaskParticitpant",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSector_SectorId",
                table: "TaskSector",
                column: "SectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskParticitpant");

            migrationBuilder.DropTable(
                name: "TaskSector");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Participant",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskSectors",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    SectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSectors", x => new { x.TaskId, x.SectorId });
                    table.ForeignKey(
                        name: "FK_TaskSectors_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskSectors_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participant_TaskId",
                table: "Participant",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSectors_SectorId",
                table: "TaskSectors",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Task_TaskId",
                table: "Participant",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
