using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class timeblock_subject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "public",
                table: "TimeBlocks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                schema: "public",
                table: "TimeBlocks",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 3, 3, 45, 20, 962, DateTimeKind.Local).AddTicks(6456), new DateTime(2024, 5, 3, 3, 45, 20, 962, DateTimeKind.Local).AddTicks(6505), new DateTime(2024, 5, 3, 3, 45, 20, 962, DateTimeKind.Local).AddTicks(6510) });

            migrationBuilder.CreateIndex(
                name: "IX_TimeBlocks_SubjectId",
                schema: "public",
                table: "TimeBlocks",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeBlocks_Subjects_SubjectId",
                schema: "public",
                table: "TimeBlocks",
                column: "SubjectId",
                principalSchema: "public",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeBlocks_Subjects_SubjectId",
                schema: "public",
                table: "TimeBlocks");

            migrationBuilder.DropIndex(
                name: "IX_TimeBlocks_SubjectId",
                schema: "public",
                table: "TimeBlocks");

            migrationBuilder.DropColumn(
                name: "Color",
                schema: "public",
                table: "TimeBlocks");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                schema: "public",
                table: "TimeBlocks");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 1, 12, 18, 38, 194, DateTimeKind.Local).AddTicks(6153), new DateTime(2024, 5, 1, 12, 18, 38, 194, DateTimeKind.Local).AddTicks(6209), new DateTime(2024, 5, 1, 12, 18, 38, 194, DateTimeKind.Local).AddTicks(6213) });
        }
    }
}
