using Microsoft.EntityFrameworkCore;
using Miki.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Miki.Bot.Models
{
    [Table("Configuration")]
    public class Config
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Discord API Token
        /// </summary>
        [Column("Token")]
        public string Token { get; set; } = "";

        /// <summary>
        /// Sentry Error Tracking
        /// </summary>
        [Column("SharpRavenKey")]
        public string SharpRavenKey { get; set; } = "";

        /// <summary>
        /// Datadog Agent host
        /// </summary>
        [Column("DatadogHost")]
        public string DatadogHost { get; set; } = "127.0.0.1";

        /// <summary>
        /// Cache connection string
        /// </summary>
        [Column("RedisConnectionString")]
        public string RedisConnectionString { get; set; } = "localhost";

        /// <summary>
        /// Miki API route
        /// </summary>
        [Column("MikiApiBaseUrl")]
        public string MikiApiBaseUrl { get; set; } = "https://api.miki.ai/";

        /// <summary>
        /// Miki API Key
        /// </summary>
        [Column("MikiApiKey")]
        public string MikiApiKey { get; set; } = "";

        /// <summary>
        /// Image API route
        /// </summary>
        [Column("ImageApiUrl")]
        public string ImageApiUrl { get; internal set; } = "";

        [Column("CdnRegionEndpoint")]
        public string CdnRegionEndpoint { get; internal set; } = "";

        [Column("CdnAccessKey")]
        public string CdnAccessKey { get; internal set; } = "";

        [Column("CdnSecretKey")]
        public string CdnSecretKey { get; internal set; } = "";
        
        [Column("RabbitUrl")]
        public string RabbitUrl { get; internal set; } = "amqp://localhost";
        
        [Column("DanbooruCredentials")]
        public string DanbooruCredentials { get; internal set; } = "";
        
        [Column("BunnyCdnKey")]
        public string BunnyCdnKey { get; internal set; }

        public Config()
        {
            Id = new Guid();
        }

        public static async Task<Config> GetOrInsertAsync(string connStr, string configId = null)
        {
            if (connStr == null)
            {
                throw new ArgumentNullException("Cannot connect to database, ensure you have configured the database connection string");
            }

            var builder = new DbContextOptionsBuilder<MikiDbContext>();
            builder.UseNpgsql(connStr, b => b.MigrationsAssembly("Miki.Bot.Models"));
            var dbContext = new MikiDbContext(builder.Options);

            Config configuration = null;

            if (!string.IsNullOrWhiteSpace(configId) && await dbContext.Configurations.AnyAsync(x => x.Id.ToString() == configId))
            {
                configuration = await dbContext.Configurations.FirstOrDefaultAsync(x => x.Id.ToString() == configId);
            }
            else
            {
                if (!await dbContext.Configurations.AnyAsync())
                {
                    configuration = await InsertNewConfigAsync(connStr);
                }
                else
                {
                    configuration = await dbContext.Configurations.FirstOrDefaultAsync();
                }
            }

            return configuration;
        }

        public static async Task<Config> InsertNewConfigAsync(string connStr)
        {
            var builder = new DbContextOptionsBuilder<MikiDbContext>();
            builder.UseNpgsql(connStr, b => b.MigrationsAssembly("Miki.Bot.Models"));
            var dbContext = new MikiDbContext(builder.Options);

            var configuration = new Config();

            await dbContext.Configurations.AddAsync(configuration);

            await dbContext.SaveChangesAsync();

            Log.Debug("New Config inserted into database with Id: " + configuration.Id);

            return configuration;
        }
    }
}
