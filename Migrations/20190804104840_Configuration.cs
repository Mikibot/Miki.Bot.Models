using Microsoft.EntityFrameworkCore.Migrations;

namespace Miki.Migrations
{
    public partial class Configuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuration",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<System.Guid>(defaultValue: new System.Guid(), nullable: false),
                    Token = table.Column<string>(nullable: true),
                    SharpRavenKey = table.Column<string>(nullable: true),
                    DatadogHost = table.Column<string>(nullable: true),
                    RedisConnectionString = table.Column<string>(nullable: true),
                    MikiApiBaseUrl = table.Column<string>(nullable: true),
                    MikiApiKey = table.Column<string>(nullable: true),
                    ImageApiUrl = table.Column<string>(nullable: true),
                    CdnRegionEndpoint = table.Column<string>(nullable: true),
                    CdnAccessKey = table.Column<string>(nullable: true),
                    CdnSecretKey = table.Column<string>(nullable: true),
                    RabbitUrl = table.Column<string>(defaultValue: "amqp://localhost"),
                    DanbooruCredentials = table.Column<string>(nullable: true),
                    BunnyCdnKey = table.Column<string>(nullable: true)
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration",
                schema: "dbo");
        }
    }
}
