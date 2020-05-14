using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Miki.Core.Migrations
{
    public partial class CustomCommands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIApplicationData",
                schema: "dbo",
                columns: table => new
                {
                    ApplicationId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIApplicationData", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "CustomCommands",
                schema: "dbo",
                columns: table => new
                {
                    guildId = table.Column<long>(nullable: false),
                    commandName = table.Column<string>(nullable: false),
                    commandBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomCommands", x => new { x.guildId, x.commandName });
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                schema: "dbo",
                columns: table => new
                {
                    ApplicationId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OwnerId = table.Column<long>(nullable: false),
                    LastResetEpoch = table.Column<long>(nullable: false),
                    ApplicationSecret = table.Column<Guid>(nullable: false, defaultValue: new Guid("8bb5eb1d-3860-4053-b8a3-1b5e6f2f7606")),
                    Permissions = table.Column<long>(nullable: false),
                    RatelimitMultiplier = table.Column<double>(nullable: false),
                    DataApplicationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_APIApplicationData_DataApplicationId",
                        column: x => x.DataApplicationId,
                        principalSchema: "dbo",
                        principalTable: "APIApplicationData",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_DataApplicationId",
                schema: "dbo",
                table: "Applications",
                column: "DataApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CustomCommands",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "APIApplicationData",
                schema: "dbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastDailyTime",
                schema: "dbo",
                table: "Users",
                nullable: false,
                defaultValueSql: "now() - interval '1 day'",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                schema: "dbo",
                table: "Users",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 24, 19, 21, 31, 571, DateTimeKind.Utc).AddTicks(965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Pastas",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 24, 19, 21, 31, 568, DateTimeKind.Utc).AddTicks(4635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfProposal",
                schema: "dbo",
                table: "Marriages",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 24, 19, 21, 31, 568, DateTimeKind.Utc).AddTicks(363));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidUntil",
                schema: "dbo",
                table: "IsDonator",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 24, 19, 21, 31, 587, DateTimeKind.Utc).AddTicks(2807));
        }
    }
}
