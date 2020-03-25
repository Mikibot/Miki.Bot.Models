namespace Miki.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddOptionalConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OptionalValues",
                schema: "dbo",
                table: "Configuration",
                type: "jsonb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionalValues",
                schema: "dbo",
                table: "Configuration");
        }
    }
}
