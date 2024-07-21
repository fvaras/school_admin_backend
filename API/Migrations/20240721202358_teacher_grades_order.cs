using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class teacher_grades_order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherGrades_Grades_GradesId",
                schema: "public",
                table: "TeacherGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherGrades_Teachers_TeachersId",
                schema: "public",
                table: "TeacherGrades");

            migrationBuilder.RenameTable(
                name: "TeacherGrades",
                schema: "public",
                newName: "TeacherGrades");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "TeacherGrades",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "GradesId",
                table: "TeacherGrades",
                newName: "GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherGrades_TeachersId",
                table: "TeacherGrades",
                newName: "IX_TeacherGrades_TeacherId");

            migrationBuilder.AddColumn<byte>(
                name: "Order",
                table: "TeacherGrades",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("845900f3-b438-4461-9ef0-3aa846085000"),
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 7, 21, 20, 23, 58, 180, DateTimeKind.Unspecified).AddTicks(4074), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 21, 20, 23, 58, 180, DateTimeKind.Unspecified).AddTicks(4077), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 21, 20, 23, 58, 180, DateTimeKind.Unspecified).AddTicks(4077), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ea8108dc-3e1d-42ab-a932-9016b22e717e"),
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(1983, 7, 21, 20, 23, 58, 180, DateTimeKind.Unspecified).AddTicks(4115), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 21, 20, 23, 58, 180, DateTimeKind.Unspecified).AddTicks(4165), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 21, 20, 23, 58, 180, DateTimeKind.Unspecified).AddTicks(4165), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherGrades_Grades_GradeId",
                table: "TeacherGrades",
                column: "GradeId",
                principalSchema: "public",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherGrades_Teachers_TeacherId",
                table: "TeacherGrades",
                column: "TeacherId",
                principalSchema: "public",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherGrades_Grades_GradeId",
                table: "TeacherGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherGrades_Teachers_TeacherId",
                table: "TeacherGrades");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "TeacherGrades");

            migrationBuilder.RenameTable(
                name: "TeacherGrades",
                newName: "TeacherGrades",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                schema: "public",
                table: "TeacherGrades",
                newName: "TeachersId");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                schema: "public",
                table: "TeacherGrades",
                newName: "GradesId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherGrades_TeacherId",
                schema: "public",
                table: "TeacherGrades",
                newName: "IX_TeacherGrades_TeachersId");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("845900f3-b438-4461-9ef0-3aa846085000"),
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 7, 20, 5, 18, 43, 620, DateTimeKind.Unspecified).AddTicks(5868), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 20, 5, 18, 43, 620, DateTimeKind.Unspecified).AddTicks(5872), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 20, 5, 18, 43, 620, DateTimeKind.Unspecified).AddTicks(5873), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ea8108dc-3e1d-42ab-a932-9016b22e717e"),
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(1983, 7, 20, 5, 18, 43, 620, DateTimeKind.Unspecified).AddTicks(5952), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 20, 5, 18, 43, 620, DateTimeKind.Unspecified).AddTicks(6042), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 20, 5, 18, 43, 620, DateTimeKind.Unspecified).AddTicks(6044), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherGrades_Grades_GradesId",
                schema: "public",
                table: "TeacherGrades",
                column: "GradesId",
                principalSchema: "public",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherGrades_Teachers_TeachersId",
                schema: "public",
                table: "TeacherGrades",
                column: "TeachersId",
                principalSchema: "public",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
