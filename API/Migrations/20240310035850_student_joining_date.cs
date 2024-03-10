using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    /// <inheritdoc />
    public partial class student_joining_date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                schema: "public",
                table: "Students",
                newName: "JoiningDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                schema: "public",
                table: "Students",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                schema: "public",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "JoiningDate",
                schema: "public",
                table: "Students",
                newName: "DateOfBirth");
        }
    }
}
