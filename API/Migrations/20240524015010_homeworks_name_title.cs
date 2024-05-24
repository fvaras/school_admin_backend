using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class homeworks_name_title : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "public",
                table: "Homeworks",
                newName: "Title");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 21, 50, 9, 693, DateTimeKind.Local).AddTicks(5021), new DateTime(2024, 5, 23, 21, 50, 9, 693, DateTimeKind.Local).AddTicks(5070), new DateTime(2024, 5, 23, 21, 50, 9, 693, DateTimeKind.Local).AddTicks(5074) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "public",
                table: "Homeworks",
                newName: "Name");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 19, 55, 29, 627, DateTimeKind.Local).AddTicks(8120), new DateTime(2024, 5, 23, 19, 55, 29, 627, DateTimeKind.Local).AddTicks(8177), new DateTime(2024, 5, 23, 19, 55, 29, 627, DateTimeKind.Local).AddTicks(8179) });
        }
    }
}
