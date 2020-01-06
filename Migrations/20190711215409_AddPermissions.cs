namespace Miki.Core.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "dbo",
                columns: table => new
                {
                    EntityId = table.Column<long>(nullable: false),
                    CommandName = table.Column<string>(nullable: false),
                    GuildId = table.Column<long>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => new { x.EntityId, x.CommandName, x.GuildId });
                    table.UniqueConstraint("AK_Permissions_CommandName_EntityId_GuildId", x => new { x.CommandName, x.EntityId, x.GuildId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_GuildId",
                schema: "dbo",
                table: "Permissions",
                column: "GuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "dbo");
        }
    }
}
