using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class timeblocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeBlocks",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<byte>(type: "smallint", nullable: false),
                    Day = table.Column<byte>(type: "smallint", nullable: false),
                    Start = table.Column<TimeSpan>(type: "interval", nullable: false),
                    End = table.Column<TimeSpan>(type: "interval", nullable: false),
                    IsRecess = table.Column<bool>(type: "boolean", nullable: false),
                    GradeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeBlocks_Grades_GradeId",
                        column: x => x.GradeId,
                        principalSchema: "public",
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 28, 17, 5, 27, 641, DateTimeKind.Local).AddTicks(870), new DateTime(2024, 4, 28, 17, 5, 27, 641, DateTimeKind.Local).AddTicks(922), new DateTime(2024, 4, 28, 17, 5, 27, 641, DateTimeKind.Local).AddTicks(924) });

            migrationBuilder.CreateIndex(
                name: "IX_TimeBlocks_GradeId",
                schema: "public",
                table: "TimeBlocks",
                column: "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeBlocks",
                schema: "public");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 28, 0, 36, 27, 848, DateTimeKind.Local).AddTicks(6172), new DateTime(2024, 4, 28, 0, 36, 27, 848, DateTimeKind.Local).AddTicks(6269), new DateTime(2024, 4, 28, 0, 36, 27, 848, DateTimeKind.Local).AddTicks(6274) });
        }
    }
}
