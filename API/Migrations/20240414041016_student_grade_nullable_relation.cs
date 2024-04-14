using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class student_grade_nullable_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                schema: "public",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 14, 0, 10, 15, 344, DateTimeKind.Local).AddTicks(3185), new DateTime(2024, 4, 14, 0, 10, 15, 344, DateTimeKind.Local).AddTicks(3246), new DateTime(2024, 4, 14, 0, 10, 15, 344, DateTimeKind.Local).AddTicks(3251) });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeId",
                schema: "public",
                table: "Students",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Grades_GradeId",
                schema: "public",
                table: "Students",
                column: "GradeId",
                principalSchema: "public",
                principalTable: "Grades",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Grades_GradeId",
                schema: "public",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GradeId",
                schema: "public",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GradeId",
                schema: "public",
                table: "Students");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 7, 9, 19, 38, 855, DateTimeKind.Local).AddTicks(1711), new DateTime(2024, 4, 7, 9, 19, 38, 855, DateTimeKind.Local).AddTicks(1756), new DateTime(2024, 4, 7, 9, 19, 38, 855, DateTimeKind.Local).AddTicks(1759) });
        }
    }
}
