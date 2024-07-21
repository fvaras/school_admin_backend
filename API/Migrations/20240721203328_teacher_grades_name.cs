using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class teacher_grades_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherGrades_Grades_GradeId",
                table: "TeacherGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherGrades_Teachers_TeacherId",
                table: "TeacherGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherGrades",
                table: "TeacherGrades");

            migrationBuilder.RenameTable(
                name: "TeacherGrades",
                newName: "GradeTeachers",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherGrades_TeacherId",
                schema: "public",
                table: "GradeTeachers",
                newName: "IX_GradeTeachers_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradeTeachers",
                schema: "public",
                table: "GradeTeachers",
                columns: new[] { "GradeId", "TeacherId" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("845900f3-b438-4461-9ef0-3aa846085000"),
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 7, 21, 20, 33, 28, 316, DateTimeKind.Unspecified).AddTicks(9270), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 21, 20, 33, 28, 316, DateTimeKind.Unspecified).AddTicks(9273), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 21, 20, 33, 28, 316, DateTimeKind.Unspecified).AddTicks(9274), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ea8108dc-3e1d-42ab-a932-9016b22e717e"),
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(1983, 7, 21, 20, 33, 28, 316, DateTimeKind.Unspecified).AddTicks(9307), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 21, 20, 33, 28, 316, DateTimeKind.Unspecified).AddTicks(9373), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 21, 20, 33, 28, 316, DateTimeKind.Unspecified).AddTicks(9374), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_GradeTeachers_Grades_GradeId",
                schema: "public",
                table: "GradeTeachers",
                column: "GradeId",
                principalSchema: "public",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeTeachers_Teachers_TeacherId",
                schema: "public",
                table: "GradeTeachers",
                column: "TeacherId",
                principalSchema: "public",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradeTeachers_Grades_GradeId",
                schema: "public",
                table: "GradeTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeTeachers_Teachers_TeacherId",
                schema: "public",
                table: "GradeTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GradeTeachers",
                schema: "public",
                table: "GradeTeachers");

            migrationBuilder.RenameTable(
                name: "GradeTeachers",
                schema: "public",
                newName: "TeacherGrades");

            migrationBuilder.RenameIndex(
                name: "IX_GradeTeachers_TeacherId",
                table: "TeacherGrades",
                newName: "IX_TeacherGrades_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherGrades",
                table: "TeacherGrades",
                columns: new[] { "GradeId", "TeacherId" });

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
    }
}
