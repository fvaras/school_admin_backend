using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class subject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    GradeId = table.Column<int>(type: "integer", nullable: false),
                    TeacherId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Grades_GradeId",
                        column: x => x.GradeId,
                        principalSchema: "public",
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "public",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 22, 0, 19, 32, 147, DateTimeKind.Local).AddTicks(7013), new DateTime(2024, 4, 22, 0, 19, 32, 147, DateTimeKind.Local).AddTicks(7071), new DateTime(2024, 4, 22, 0, 19, 32, 147, DateTimeKind.Local).AddTicks(7075) });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_GradeId",
                schema: "public",
                table: "Subjects",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                schema: "public",
                table: "Subjects",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subjects",
                schema: "public");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 20, 23, 34, 12, 278, DateTimeKind.Local).AddTicks(5335), new DateTime(2024, 4, 20, 23, 34, 12, 278, DateTimeKind.Local).AddTicks(5380), new DateTime(2024, 4, 20, 23, 34, 12, 278, DateTimeKind.Local).AddTicks(5385) });
        }
    }
}
