namespace Miki.Core.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;
    using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

    public partial class AddIsBanned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "commandBody",
                schema: "dbo",
                table: "CustomCommands",
                newName: "CommandBody");

            migrationBuilder.RenameColumn(
                name: "commandName",
                schema: "dbo",
                table: "CustomCommands",
                newName: "CommandName");

            migrationBuilder.RenameColumn(
                name: "guildId",
                schema: "dbo",
                table: "CustomCommands",
                newName: "GuildId");

            migrationBuilder.CreateTable(
                name: "IsBanned",
                schema: "dbo",
                columns: table => new
                {
                    BanId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<long>(nullable: false),
                    TimeOfBan = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsBanned", x => new { x.BanId, x.UserId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_IsBanned_UserId",
                schema: "dbo",
                table: "IsBanned",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IsBanned",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "CommandBody",
                schema: "dbo",
                table: "CustomCommands",
                newName: "commandBody");

            migrationBuilder.RenameColumn(
                name: "CommandName",
                schema: "dbo",
                table: "CustomCommands",
                newName: "commandName");

            migrationBuilder.RenameColumn(
                name: "GuildId",
                schema: "dbo",
                table: "CustomCommands",
                newName: "guildId");         
        }
    }
}
