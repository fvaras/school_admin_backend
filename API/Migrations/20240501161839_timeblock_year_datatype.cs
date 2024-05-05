using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class timeblock_year_datatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                schema: "public",
                table: "TimeBlocks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 1, 12, 18, 38, 194, DateTimeKind.Local).AddTicks(6153), new DateTime(2024, 5, 1, 12, 18, 38, 194, DateTimeKind.Local).AddTicks(6209), new DateTime(2024, 5, 1, 12, 18, 38, 194, DateTimeKind.Local).AddTicks(6213) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Year",
                schema: "public",
                table: "TimeBlocks",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 1, 12, 8, 53, 776, DateTimeKind.Local).AddTicks(9423), new DateTime(2024, 5, 1, 12, 8, 53, 776, DateTimeKind.Local).AddTicks(9480), new DateTime(2024, 5, 1, 12, 8, 53, 776, DateTimeKind.Local).AddTicks(9484) });
        }
    }
}
