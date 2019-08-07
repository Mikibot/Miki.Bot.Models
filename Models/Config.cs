using System;

namespace Miki.Bot.Models
{
	public class Config
	{
        public Guid Id { get; set; } = new Guid();

		/// <summary>
		/// Discord API Token
		/// </summary>
		public string Token { get; set; } = "";

		/// <summary>
		/// Sentry Error Tracking
		/// </summary>
		public string SharpRavenKey { get; set; } = "";

		/// <summary>
		/// Datadog Agent host
		/// </summary>
		public string DatadogHost { get; set; } = "127.0.0.1";

		/// <summary>
		/// Cache connection string
		/// </summary>
		public string RedisConnectionString { get; set; } = "localhost";

		/// <summary>
		/// Miki API route
		/// </summary>
		public string MikiApiBaseUrl { get; set; } = "https://api.miki.ai/";

		/// <summary>
		/// Miki API Key
		/// </summary>
		public string MikiApiKey { get; set; } = "";

		/// <summary>
		/// Image API route
		/// </summary>
		public string ImageApiUrl { get; internal set; } = "";

		public string CdnRegionEndpoint { get; internal set; } = "";

		public string CdnAccessKey { get; internal set; } = "";

		public string CdnSecretKey { get; internal set; } = "";

		public string RabbitUrl { get; internal set; } = "amqp://localhost";

		public string DanbooruCredentials { get; internal set; } = "";

        public string BunnyCdnKey { get; internal set; }
    }
}