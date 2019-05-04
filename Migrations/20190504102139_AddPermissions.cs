using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Miki.Core.Migrations
{
    public partial class AddPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    GuildId = table.Column<long>(nullable: false),
                    PermissionLevel = table.Column<int>(nullable: false),
                    LocalExperienceServerId = table.Column<long>(nullable: true),
                    LocalExperienceUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => new { x.UserId, x.GuildId });
                    table.ForeignKey(
                        name: "FK_Permissions_LocalExperience_LocalExperienceServerId_LocalEx~",
                        columns: x => new { x.LocalExperienceServerId, x.LocalExperienceUserId },
                        principalSchema: "dbo",
                        principalTable: "LocalExperience",
                        principalColumns: new[] { "ServerId", "UserId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogs",
                schema: "dbo",
                columns: table => new
                {
                    LogId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<long>(nullable: false),
                    Action = table.Column<int>(nullable: false),
                    Context = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogs", x => x.LogId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_LocalExperienceServerId_LocalExperienceUserId",
                schema: "dbo",
                table: "Permissions",
                columns: new[] { "LocalExperienceServerId", "LocalExperienceUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_UserId",
                schema: "dbo",
                table: "UserLogs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserLogs",
                schema: "dbo");
        }
    }
}
