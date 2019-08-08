using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Miki.Bot.Models
{
    [Table("Configuration")]
    public class Config
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; } = new Guid();

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
    }
}
