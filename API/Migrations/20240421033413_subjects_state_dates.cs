using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class subjects_state_dates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 20, 23, 34, 12, 278, DateTimeKind.Local).AddTicks(5335), new DateTime(2024, 4, 20, 23, 34, 12, 278, DateTimeKind.Local).AddTicks(5380), new DateTime(2024, 4, 20, 23, 34, 12, 278, DateTimeKind.Local).AddTicks(5385) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 20, 21, 11, 11, 767, DateTimeKind.Local).AddTicks(8068), new DateTime(2024, 4, 20, 21, 11, 11, 767, DateTimeKind.Local).AddTicks(8114), new DateTime(2024, 4, 20, 21, 11, 11, 767, DateTimeKind.Local).AddTicks(8119) });
        }
    }
}
