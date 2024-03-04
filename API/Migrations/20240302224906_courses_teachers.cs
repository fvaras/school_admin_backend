using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    /// <inheritdoc />
    public partial class courses_teachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCurso",
                schema: "public",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                schema: "public",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "IdEstado",
                schema: "public",
                table: "Students",
                newName: "StateId");

            migrationBuilder.AddColumn<string>(
                name: "Rut",
                schema: "public",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "public",
                table: "Students",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "public",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "IdGender",
                schema: "public",
                table: "Students",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                schema: "public",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "integer", nullable: false),
                    TeachersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => new { x.CoursesId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalSchema: "public",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalSchema: "public",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_TeachersId",
                schema: "public",
                table: "TeacherCourses",
                column: "TeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherCourses",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "Rut",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "public",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "public",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IdGender",
                schema: "public",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StateId",
                schema: "public",
                table: "Students",
                newName: "IdEstado");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "public",
                table: "Students",
                newName: "Nombre");

            migrationBuilder.AddColumn<int>(
                name: "IdCurso",
                schema: "public",
                table: "Students",
                type: "integer",
                nullable: true);
        }
    }
}
