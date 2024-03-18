using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class user_entity__relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IdGender",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "public",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                schema: "public",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Email",
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

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "public",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "public",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Rut",
                schema: "public",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "public",
                table: "StudentGuardians");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "public",
                table: "StudentGuardians");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "public",
                table: "StudentGuardians");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "public",
                table: "StudentGuardians");

            migrationBuilder.DropColumn(
                name: "IdGender",
                schema: "public",
                table: "StudentGuardians");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "public",
                table: "StudentGuardians");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "public",
                table: "StudentGuardians");

            migrationBuilder.DropColumn(
                name: "Rut",
                schema: "public",
                table: "StudentGuardians");

            migrationBuilder.RenameColumn(
                name: "IdState",
                schema: "public",
                table: "Users",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "IdState",
                schema: "public",
                table: "Teachers",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "IdState",
                schema: "public",
                table: "StudentGuardians",
                newName: "StateId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "public",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                schema: "public",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                schema: "public",
                table: "Users",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "public",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<byte>(
                name: "StateId",
                schema: "public",
                table: "Students",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "public",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "public",
                table: "StudentGuardians",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "BirthDate", "CreatedAt", "Phone", "UpdatedAt" },
                values: new object[] { "", new DateTime(2024, 3, 17, 19, 38, 58, 557, DateTimeKind.Local).AddTicks(7989), new DateTime(2024, 3, 17, 19, 38, 58, 557, DateTimeKind.Local).AddTicks(8034), "", new DateTime(2024, 3, 17, 19, 38, 58, 557, DateTimeKind.Local).AddTicks(8039) });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                schema: "public",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGuardians_UserId",
                schema: "public",
                table: "StudentGuardians",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGuardians_Users_UserId",
                schema: "public",
                table: "StudentGuardians",
                column: "UserId",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserId",
                schema: "public",
                table: "Students",
                column: "UserId",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGuardians_Users_UserId",
                schema: "public",
                table: "StudentGuardians");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserId",
                schema: "public",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                schema: "public",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_StudentGuardians_UserId",
                schema: "public",
                table: "StudentGuardians");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "public",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                schema: "public",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "public",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "public",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "public",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "public",
                table: "StudentGuardians");

            migrationBuilder.RenameColumn(
                name: "StateId",
                schema: "public",
                table: "Users",
                newName: "IdState");

            migrationBuilder.RenameColumn(
                name: "StateId",
                schema: "public",
                table: "Teachers",
                newName: "IdState");

            migrationBuilder.RenameColumn(
                name: "StateId",
                schema: "public",
                table: "StudentGuardians",
                newName: "IdState");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "public",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                schema: "public",
                table: "Teachers",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "IdGender",
                schema: "public",
                table: "Teachers",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "public",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                schema: "public",
                table: "Students",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "public",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                schema: "public",
                table: "Students",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "public",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "public",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "public",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rut",
                schema: "public",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "public",
                table: "StudentGuardians",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "public",
                table: "StudentGuardians",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "public",
                table: "StudentGuardians",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "public",
                table: "StudentGuardians",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "IdGender",
                schema: "public",
                table: "StudentGuardians",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "public",
                table: "StudentGuardians",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "public",
                table: "StudentGuardians",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rut",
                schema: "public",
                table: "StudentGuardians",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 15, 57, 29, 101, DateTimeKind.Local).AddTicks(4598), new DateTime(2024, 3, 17, 15, 57, 29, 101, DateTimeKind.Local).AddTicks(4645) });
        }
    }
}
