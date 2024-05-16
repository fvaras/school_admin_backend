using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class plannings_timeblocks_with_date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PlanningTimeBlock",
                schema: "public",
                newName: "PlanningTimeBlock");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "PlanningTimeBlock",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 12, 2, 32, 3, 947, DateTimeKind.Local).AddTicks(2170), new DateTime(2024, 5, 12, 2, 32, 3, 947, DateTimeKind.Local).AddTicks(2225), new DateTime(2024, 5, 12, 2, 32, 3, 947, DateTimeKind.Local).AddTicks(2230) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "PlanningTimeBlock");

            migrationBuilder.RenameTable(
                name: "PlanningTimeBlock",
                newName: "PlanningTimeBlock",
                newSchema: "public");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 12, 0, 25, 0, 663, DateTimeKind.Local).AddTicks(9478), new DateTime(2024, 5, 12, 0, 25, 0, 663, DateTimeKind.Local).AddTicks(9531), new DateTime(2024, 5, 12, 0, 25, 0, 663, DateTimeKind.Local).AddTicks(9536) });
        }
    }
}
