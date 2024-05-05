using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class timeblock_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlockName",
                schema: "public",
                table: "TimeBlocks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 1, 12, 8, 53, 776, DateTimeKind.Local).AddTicks(9423), new DateTime(2024, 5, 1, 12, 8, 53, 776, DateTimeKind.Local).AddTicks(9480), new DateTime(2024, 5, 1, 12, 8, 53, 776, DateTimeKind.Local).AddTicks(9484) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockName",
                schema: "public",
                table: "TimeBlocks");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 28, 17, 5, 27, 641, DateTimeKind.Local).AddTicks(870), new DateTime(2024, 4, 28, 17, 5, 27, 641, DateTimeKind.Local).AddTicks(922), new DateTime(2024, 4, 28, 17, 5, 27, 641, DateTimeKind.Local).AddTicks(924) });
        }
    }
}
