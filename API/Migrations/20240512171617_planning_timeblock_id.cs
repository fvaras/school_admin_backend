using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class planning_timeblock_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlanningTimeBlock",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 16, 16, 541, DateTimeKind.Local).AddTicks(4611), new DateTime(2024, 5, 12, 13, 16, 16, 541, DateTimeKind.Local).AddTicks(4651), new DateTime(2024, 5, 12, 13, 16, 16, 541, DateTimeKind.Local).AddTicks(4653) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlanningTimeBlock");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 12, 2, 36, 10, 617, DateTimeKind.Local).AddTicks(1972), new DateTime(2024, 5, 12, 2, 36, 10, 617, DateTimeKind.Local).AddTicks(2049), new DateTime(2024, 5, 12, 2, 36, 10, 617, DateTimeKind.Local).AddTicks(2054) });
        }
    }
}
