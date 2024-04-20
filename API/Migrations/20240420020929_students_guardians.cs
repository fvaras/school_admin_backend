using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class students_guardians : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentGuardians",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "Guardians",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Relation = table.Column<string>(type: "text", nullable: false),
                    StateId = table.Column<byte>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guardians_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuardianStudent",
                schema: "public",
                columns: table => new
                {
                    GuardiansId = table.Column<int>(type: "integer", nullable: false),
                    StudentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuardianStudent", x => new { x.GuardiansId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_GuardianStudent_Guardians_GuardiansId",
                        column: x => x.GuardiansId,
                        principalSchema: "public",
                        principalTable: "Guardians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuardianStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalSchema: "public",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 19, 22, 9, 29, 77, DateTimeKind.Local).AddTicks(9432), new DateTime(2024, 4, 19, 22, 9, 29, 77, DateTimeKind.Local).AddTicks(9466), new DateTime(2024, 4, 19, 22, 9, 29, 77, DateTimeKind.Local).AddTicks(9468) });

            migrationBuilder.CreateIndex(
                name: "IX_GuardianStudent_StudentsId",
                schema: "public",
                table: "GuardianStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_UserId",
                schema: "public",
                table: "Guardians",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuardianStudent",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Guardians",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "StudentGuardians",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Relation = table.Column<string>(type: "text", nullable: false),
                    StateId = table.Column<byte>(type: "smallint", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGuardians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGuardians_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 14, 0, 10, 15, 344, DateTimeKind.Local).AddTicks(3185), new DateTime(2024, 4, 14, 0, 10, 15, 344, DateTimeKind.Local).AddTicks(3246), new DateTime(2024, 4, 14, 0, 10, 15, 344, DateTimeKind.Local).AddTicks(3251) });

            migrationBuilder.CreateIndex(
                name: "IX_StudentGuardians_UserId",
                schema: "public",
                table: "StudentGuardians",
                column: "UserId");
        }
    }
}
