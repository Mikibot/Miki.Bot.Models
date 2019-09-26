using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Miki.Migrations
{
    public partial class permissions_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Permissions_CommandName_EntityId_GuildId",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.AlterColumn<string>(
                name: "CommandName",
                schema: "dbo",
                table: "Permissions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<long>(
                name: "PermissionId",
                schema: "dbo",
                table: "Permissions",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                schema: "dbo",
                table: "Permissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_EntityId_CommandName_GuildId",
                schema: "dbo",
                table: "Permissions",
                columns: new[] { "EntityId", "CommandName", "GuildId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_EntityId_CommandName_GuildId",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                schema: "dbo",
                table: "Permissions");

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
        }
    }
}
