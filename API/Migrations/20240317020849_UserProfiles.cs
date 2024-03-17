using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class UserProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PersonalAddress",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PersonalEmail",
                schema: "public",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "Rut",
                schema: "public",
                table: "Teachers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "PersonalPhone",
                schema: "public",
                table: "Teachers",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                schema: "public",
                table: "Teachers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "public",
                table: "Teachers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Profiles",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Rut = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IdState = table.Column<byte>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                schema: "public",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => new { x.ProfileId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserProfiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "public",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Profiles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Teacher" },
                    { 3, "Student" },
                    { 4, "Guardian" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "IdState", "LastName", "Password", "Rut", "UpdatedAt", "UserName" },
                values: new object[] { 1, new DateTime(2024, 3, 16, 23, 8, 49, 108, DateTimeKind.Local).AddTicks(8837), "fdovarasc@gmail.com", "admin", (byte)1, "", "admin", "19", new DateTime(2024, 3, 16, 23, 8, 49, 108, DateTimeKind.Local).AddTicks(8879), "admin" });

            migrationBuilder.InsertData(
                schema: "public",
                table: "UserProfiles",
                columns: new[] { "ProfileId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                schema: "public",
                table: "Teachers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                schema: "public",
                table: "UserProfiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Users_UserId",
                schema: "public",
                table: "Teachers",
                column: "UserId",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Users_UserId",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "UserProfiles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Profiles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserId",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IdUser",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "public",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "Phone",
                schema: "public",
                table: "Teachers",
                newName: "Rut");

            migrationBuilder.RenameColumn(
                name: "Address",
                schema: "public",
                table: "Teachers",
                newName: "PersonalPhone");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "public",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "public",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalAddress",
                schema: "public",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalEmail",
                schema: "public",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
