using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace school_admin_api.Migrations
{
    public partial class planning_timeblock_auto_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PlanningTimeBlock",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 12, 19, 16, 24, 458, DateTimeKind.Local).AddTicks(4627), new DateTime(2024, 5, 12, 19, 16, 24, 458, DateTimeKind.Local).AddTicks(4674), new DateTime(2024, 5, 12, 19, 16, 24, 458, DateTimeKind.Local).AddTicks(4677) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PlanningTimeBlock",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 16, 16, 541, DateTimeKind.Local).AddTicks(4611), new DateTime(2024, 5, 12, 13, 16, 16, 541, DateTimeKind.Local).AddTicks(4651), new DateTime(2024, 5, 12, 13, 16, 16, 541, DateTimeKind.Local).AddTicks(4653) });
        }
    }
}
