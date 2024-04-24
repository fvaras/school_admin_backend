using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class subjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 20, 21, 11, 11, 767, DateTimeKind.Local).AddTicks(8068), new DateTime(2024, 4, 20, 21, 11, 11, 767, DateTimeKind.Local).AddTicks(8114), new DateTime(2024, 4, 20, 21, 11, 11, 767, DateTimeKind.Local).AddTicks(8119) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 19, 22, 9, 29, 77, DateTimeKind.Local).AddTicks(9432), new DateTime(2024, 4, 19, 22, 9, 29, 77, DateTimeKind.Local).AddTicks(9466), new DateTime(2024, 4, 19, 22, 9, 29, 77, DateTimeKind.Local).AddTicks(9468) });
        }
    }
}
