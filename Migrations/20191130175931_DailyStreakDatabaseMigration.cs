using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Miki.Migrations
{
    public partial class DailyStreakDatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyStreaks",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    CurrentStreak = table.Column<long>(defaultValue: 0, nullable: false),
                    LastStreakTime = table.Column<DateTime>(defaultValue: DateTime.UtcNow, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyStreak", x => new { x.UserId });
                    table.ForeignKey(
                        name: "FK_DailyStreak_UserID",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyStreaks",
                schema: "dbo");
        }
    }
}
