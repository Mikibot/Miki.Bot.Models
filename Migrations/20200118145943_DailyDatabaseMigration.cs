using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    CurrentStreak = table.Column<long>(defaultValue: 0, nullable: false),
                    LongestStreak = table.Column<long>(defaultValue: 20, nullable: false),
                    LastClaimTime = table.Column<DateTime>(defaultValue: DateTime.UtcNow, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dailies", x => new { x.UserId });
                    table.ForeignKey(
                        name: "FK_Dailies_UserID",
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
                name: "Dailies",
                schema: "dbo");
        }
    }
}
