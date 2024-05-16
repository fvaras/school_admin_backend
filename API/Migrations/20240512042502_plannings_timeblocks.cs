using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class plannings_timeblocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "public",
                table: "Subjects",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlanningTimeBlock",
                schema: "public",
                columns: table => new
                {
                    PlanningsId = table.Column<int>(type: "integer", nullable: false),
                    TimeBlocksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningTimeBlock", x => new { x.PlanningsId, x.TimeBlocksId });
                    table.ForeignKey(
                        name: "FK_PlanningTimeBlock_Plannings_PlanningsId",
                        column: x => x.PlanningsId,
                        principalSchema: "public",
                        principalTable: "Plannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanningTimeBlock_TimeBlocks_TimeBlocksId",
                        column: x => x.TimeBlocksId,
                        principalSchema: "public",
                        principalTable: "TimeBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 12, 0, 25, 0, 663, DateTimeKind.Local).AddTicks(9478), new DateTime(2024, 5, 12, 0, 25, 0, 663, DateTimeKind.Local).AddTicks(9531), new DateTime(2024, 5, 12, 0, 25, 0, 663, DateTimeKind.Local).AddTicks(9536) });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningTimeBlock_TimeBlocksId",
                schema: "public",
                table: "PlanningTimeBlock",
                column: "TimeBlocksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanningTimeBlock",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "Color",
                schema: "public",
                table: "Subjects");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 3, 3, 45, 20, 962, DateTimeKind.Local).AddTicks(6456), new DateTime(2024, 5, 3, 3, 45, 20, 962, DateTimeKind.Local).AddTicks(6505), new DateTime(2024, 5, 3, 3, 45, 20, 962, DateTimeKind.Local).AddTicks(6510) });
        }
    }
}
