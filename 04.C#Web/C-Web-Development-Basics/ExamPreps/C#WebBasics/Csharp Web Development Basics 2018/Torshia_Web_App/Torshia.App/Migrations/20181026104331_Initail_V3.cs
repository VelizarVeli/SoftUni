using Microsoft.EntityFrameworkCore.Migrations;

namespace Torshia.App.Migrations
{
    public partial class Initail_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_Task_TaskId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_User_TaskId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskParticitpant_Participant_ParticipantId",
                table: "TaskParticitpant");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskParticitpant_Task_TaskId",
                table: "TaskParticitpant");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSector_Sector_SectorId",
                table: "TaskSector");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSector_Task_TaskId",
                table: "TaskSector");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskSector",
                table: "TaskSector");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskParticitpant",
                table: "TaskParticitpant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sector",
                table: "Sector");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participant",
                table: "Participant");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TaskSector",
                newName: "TaskSectors");

            migrationBuilder.RenameTable(
                name: "TaskParticitpant",
                newName: "TaskParticipants");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "Sector",
                newName: "Sectors");

            migrationBuilder.RenameTable(
                name: "Report",
                newName: "Reports");

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participants");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSector_SectorId",
                table: "TaskSectors",
                newName: "IX_TaskSectors_SectorId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskParticitpant_ParticipantId",
                table: "TaskParticipants",
                newName: "IX_TaskParticipants_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Report_TaskId",
                table: "Reports",
                newName: "IX_Reports_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskSectors",
                table: "TaskSectors",
                columns: new[] { "TaskId", "SectorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskParticipants",
                table: "TaskParticipants",
                columns: new[] { "TaskId", "ParticipantId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sectors",
                table: "Sectors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Tasks_TaskId",
                table: "Reports",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_TaskId",
                table: "Reports",
                column: "TaskId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskParticipants_Participants_ParticipantId",
                table: "TaskParticipants",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskParticipants_Tasks_TaskId",
                table: "TaskParticipants",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSectors_Sectors_SectorId",
                table: "TaskSectors",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSectors_Tasks_TaskId",
                table: "TaskSectors",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Tasks_TaskId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_TaskId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskParticipants_Participants_ParticipantId",
                table: "TaskParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskParticipants_Tasks_TaskId",
                table: "TaskParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSectors_Sectors_SectorId",
                table: "TaskSectors");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSectors_Tasks_TaskId",
                table: "TaskSectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskSectors",
                table: "TaskSectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskParticipants",
                table: "TaskParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sectors",
                table: "Sectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "TaskSectors",
                newName: "TaskSector");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "TaskParticipants",
                newName: "TaskParticitpant");

            migrationBuilder.RenameTable(
                name: "Sectors",
                newName: "Sector");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "Report");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participant");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSectors_SectorId",
                table: "TaskSector",
                newName: "IX_TaskSector_SectorId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskParticipants_ParticipantId",
                table: "TaskParticitpant",
                newName: "IX_TaskParticitpant_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_TaskId",
                table: "Report",
                newName: "IX_Report_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskSector",
                table: "TaskSector",
                columns: new[] { "TaskId", "SectorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskParticitpant",
                table: "TaskParticitpant",
                columns: new[] { "TaskId", "ParticipantId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sector",
                table: "Sector",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participant",
                table: "Participant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Task_TaskId",
                table: "Report",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_User_TaskId",
                table: "Report",
                column: "TaskId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskParticitpant_Participant_ParticipantId",
                table: "TaskParticitpant",
                column: "ParticipantId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskParticitpant_Task_TaskId",
                table: "TaskParticitpant",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSector_Sector_SectorId",
                table: "TaskSector",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSector_Task_TaskId",
                table: "TaskSector",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
