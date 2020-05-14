using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Miki.Core.Migrations
{
    public partial class ModelIterations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                schema: "dbo",
                table: "Users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 26, 6, 13, 11, 314, DateTimeKind.Utc).AddTicks(8393));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Pastas",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 26, 6, 13, 11, 313, DateTimeKind.Utc).AddTicks(2576));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfProposal",
                schema: "dbo",
                table: "Marriages",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 26, 6, 13, 11, 312, DateTimeKind.Utc).AddTicks(9165));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidUntil",
                schema: "dbo",
                table: "IsDonator",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 26, 6, 13, 11, 324, DateTimeKind.Utc).AddTicks(4549));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastRivalRenewed",
                schema: "dbo",
                table: "GuildUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "now() - INTERVAL '1 day'");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationSecret",
                schema: "dbo",
                table: "Applications",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("72d314d0-e555-4952-b6fe-c31829562ae1"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UnlockedAt",
                schema: "dbo",
                table: "Achievements",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "now()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                schema: "dbo",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 26, 6, 13, 11, 314, DateTimeKind.Utc).AddTicks(8393),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Pastas",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 26, 6, 13, 11, 313, DateTimeKind.Utc).AddTicks(2576),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfProposal",
                schema: "dbo",
                table: "Marriages",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 26, 6, 13, 11, 312, DateTimeKind.Utc).AddTicks(9165),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidUntil",
                schema: "dbo",
                table: "IsDonator",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 26, 6, 13, 11, 324, DateTimeKind.Utc).AddTicks(4549),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastRivalRenewed",
                schema: "dbo",
                table: "GuildUsers",
                nullable: false,
                defaultValueSql: "now() - INTERVAL '1 day'",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationSecret",
                schema: "dbo",
                table: "Applications",
                nullable: false,
                defaultValue: new Guid("72d314d0-e555-4952-b6fe-c31829562ae1"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UnlockedAt",
                schema: "dbo",
                table: "Achievements",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime));
        }
    }
}
