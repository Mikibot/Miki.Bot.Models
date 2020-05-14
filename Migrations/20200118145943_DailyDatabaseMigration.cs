using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Miki.Migrations
{
    public partial class DailyDatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dailies",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    CurrentStreak = table.Column<int>(defaultValue: 0, nullable: false),
                    LongestStreak = table.Column<int>(defaultValue: 0, nullable: false),
                    LastClaimTime = table.Column<DateTime>(defaultValue: DateTime.UtcNow, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dailies", x => new { x.UserId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dailies",
                schema: "dbo");
        }
    }
}
