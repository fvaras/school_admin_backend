using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class Teacher_User_Relation_FIX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                schema: "public",
                table: "Teachers");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 0, 1, 20, 476, DateTimeKind.Local).AddTicks(8302), new DateTime(2024, 3, 17, 0, 1, 20, 476, DateTimeKind.Local).AddTicks(8340) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                schema: "public",
                table: "Teachers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 16, 23, 8, 49, 108, DateTimeKind.Local).AddTicks(8837), new DateTime(2024, 3, 16, 23, 8, 49, 108, DateTimeKind.Local).AddTicks(8879) });
        }
    }
}
