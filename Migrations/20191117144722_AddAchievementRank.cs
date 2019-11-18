using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Miki.Migrations
{
    public partial class AddAchievementRank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_EntityId_CommandName_GuildId",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievements",
                schema: "dbo",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.AlterColumn<string>(
                name: "CommandName",
                schema: "dbo",
                table: "Permissions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Permissions_CommandName_EntityId_GuildId",
                schema: "dbo",
                table: "Permissions",
                columns: new[] { "CommandName", "EntityId", "GuildId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                schema: "dbo",
                table: "Permissions",
                columns: new[] { "EntityId", "CommandName", "GuildId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievements",
                schema: "dbo",
                table: "Achievements",
                columns: new[] { "UserId", "Name", "Rank" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Permissions_CommandName_EntityId_GuildId",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievements",
                schema: "dbo",
                table: "Achievements");

            migrationBuilder.AlterColumn<string>(
                name: "CommandName",
                schema: "dbo",
                table: "Permissions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<long>(
                name: "PermissionId",
                schema: "dbo",
                table: "Permissions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                schema: "dbo",
                table: "Permissions",
                column: "PermissionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievements",
                schema: "dbo",
                table: "Achievements",
                columns: new[] { "UserId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_EntityId_CommandName_GuildId",
                schema: "dbo",
                table: "Permissions",
                columns: new[] { "EntityId", "CommandName", "GuildId" });
        }
    }
}
