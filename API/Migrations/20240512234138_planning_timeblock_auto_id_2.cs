using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class planning_timeblock_auto_id_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanningTimeBlock",
                table: "PlanningTimeBlock");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanningTimeBlock",
                table: "PlanningTimeBlock",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 12, 19, 41, 37, 753, DateTimeKind.Local).AddTicks(7624), new DateTime(2024, 5, 12, 19, 41, 37, 753, DateTimeKind.Local).AddTicks(7677), new DateTime(2024, 5, 12, 19, 41, 37, 753, DateTimeKind.Local).AddTicks(7681) });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningTimeBlock_PlanningId_TimeBlockId_Date",
                table: "PlanningTimeBlock",
                columns: new[] { "PlanningId", "TimeBlockId", "Date" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanningTimeBlock",
                table: "PlanningTimeBlock");

            migrationBuilder.DropIndex(
                name: "IX_PlanningTimeBlock_PlanningId_TimeBlockId_Date",
                table: "PlanningTimeBlock");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanningTimeBlock",
                table: "PlanningTimeBlock",
                columns: new[] { "PlanningId", "TimeBlockId" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 12, 19, 16, 24, 458, DateTimeKind.Local).AddTicks(4627), new DateTime(2024, 5, 12, 19, 16, 24, 458, DateTimeKind.Local).AddTicks(4674), new DateTime(2024, 5, 12, 19, 16, 24, 458, DateTimeKind.Local).AddTicks(4677) });
        }
    }
}
