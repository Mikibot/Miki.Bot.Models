namespace Miki.Bot.Models
{
    public class Connection
	{
		public ulong UserId { get; set; }

		public long DiscordUserId { get; set; }
		public string PatreonUserId { get; set; }

		public User User { get; set; }
	}
}