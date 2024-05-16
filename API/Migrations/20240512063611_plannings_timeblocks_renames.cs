using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class plannings_timeblocks_renames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningTimeBlock_Plannings_PlanningsId",
                table: "PlanningTimeBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanningTimeBlock_TimeBlocks_TimeBlocksId",
                table: "PlanningTimeBlock");

            migrationBuilder.RenameColumn(
                name: "TimeBlocksId",
                table: "PlanningTimeBlock",
                newName: "TimeBlockId");

            migrationBuilder.RenameColumn(
                name: "PlanningsId",
                table: "PlanningTimeBlock",
                newName: "PlanningId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanningTimeBlock_TimeBlocksId",
                table: "PlanningTimeBlock",
                newName: "IX_PlanningTimeBlock_TimeBlockId");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 12, 2, 36, 10, 617, DateTimeKind.Local).AddTicks(1972), new DateTime(2024, 5, 12, 2, 36, 10, 617, DateTimeKind.Local).AddTicks(2049), new DateTime(2024, 5, 12, 2, 36, 10, 617, DateTimeKind.Local).AddTicks(2054) });

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningTimeBlock_Plannings_PlanningId",
                table: "PlanningTimeBlock",
                column: "PlanningId",
                principalSchema: "public",
                principalTable: "Plannings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningTimeBlock_TimeBlocks_TimeBlockId",
                table: "PlanningTimeBlock",
                column: "TimeBlockId",
                principalSchema: "public",
                principalTable: "TimeBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningTimeBlock_Plannings_PlanningId",
                table: "PlanningTimeBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanningTimeBlock_TimeBlocks_TimeBlockId",
                table: "PlanningTimeBlock");

            migrationBuilder.RenameColumn(
                name: "TimeBlockId",
                table: "PlanningTimeBlock",
                newName: "TimeBlocksId");

            migrationBuilder.RenameColumn(
                name: "PlanningId",
                table: "PlanningTimeBlock",
                newName: "PlanningsId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanningTimeBlock_TimeBlockId",
                table: "PlanningTimeBlock",
                newName: "IX_PlanningTimeBlock_TimeBlocksId");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 12, 2, 32, 3, 947, DateTimeKind.Local).AddTicks(2170), new DateTime(2024, 5, 12, 2, 32, 3, 947, DateTimeKind.Local).AddTicks(2225), new DateTime(2024, 5, 12, 2, 32, 3, 947, DateTimeKind.Local).AddTicks(2230) });

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningTimeBlock_Plannings_PlanningsId",
                table: "PlanningTimeBlock",
                column: "PlanningsId",
                principalSchema: "public",
                principalTable: "Plannings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningTimeBlock_TimeBlocks_TimeBlocksId",
                table: "PlanningTimeBlock",
                column: "TimeBlocksId",
                principalSchema: "public",
                principalTable: "TimeBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
