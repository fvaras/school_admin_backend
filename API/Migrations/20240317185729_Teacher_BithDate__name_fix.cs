using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class Teacher_BithDate__name_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                schema: "public",
                table: "Teachers",
                newName: "BirthDate");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 15, 57, 29, 101, DateTimeKind.Local).AddTicks(4598), new DateTime(2024, 3, 17, 15, 57, 29, 101, DateTimeKind.Local).AddTicks(4645) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                schema: "public",
                table: "Teachers",
                newName: "DateOfBirth");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 0, 1, 20, 476, DateTimeKind.Local).AddTicks(8302), new DateTime(2024, 3, 17, 0, 1, 20, 476, DateTimeKind.Local).AddTicks(8340) });
        }
    }
}
