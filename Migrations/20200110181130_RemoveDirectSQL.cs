namespace Miki.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveDirectSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pastas_Users_CreatorId",
                schema: "dbo",
                table: "Pastas");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Permissions_CommandName_EntityId_GuildId",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Pastas_CreatorId",
                schema: "dbo",
                table: "Pastas");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "dbo",
                table: "Pastas",
                nullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StatusTime",
                schema: "dbo",
                table: "DonatorKey",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldDefaultValueSql: "interval '31 days'");

            migrationBuilder.AlterColumn<Guid>(
                name: "Key",
                schema: "dbo",
                table: "DonatorKey",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.CreateIndex(
                name: "IX_Pastas_UserId",
                schema: "dbo",
                table: "Pastas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pastas_Users_UserId",
                schema: "dbo",
                table: "Pastas",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pastas_Users_UserId",
                schema: "dbo",
                table: "Pastas");

            migrationBuilder.DropIndex(
                name: "IX_Pastas_UserId",
                schema: "dbo",
                table: "Pastas");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Pastas");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StatusTime",
                schema: "dbo",
                table: "DonatorKey",
                type: "interval",
                nullable: false,
                defaultValueSql: "interval '31 days'",
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<Guid>(
                name: "Key",
                schema: "dbo",
                table: "DonatorKey",
                type: "uuid",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(Guid));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Permissions_CommandName_EntityId_GuildId",
                schema: "dbo",
                table: "Permissions",
                columns: new[] { "CommandName", "EntityId", "GuildId" });

            migrationBuilder.CreateIndex(
                name: "IX_Pastas_CreatorId",
                schema: "dbo",
                table: "Pastas",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pastas_Users_CreatorId",
                schema: "dbo",
                table: "Pastas",
                column: "CreatorId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
