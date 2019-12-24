namespace Miki.Bot.Models
{
	using Microsoft.EntityFrameworkCore;
	using System.Threading.Tasks;

	public class LevelRole
	{
		public long GuildId { get; set; }
		public long RoleId { get; set; }

		public int RequiredLevel { get; set; } = 0;
		public bool Automatic { get; set; } = false;
		public bool Optable { get; set; } = false;
		public long RequiredRole { get; set; } = 0;
		public int Price { get; set; } = 0;

		public static async Task<LevelRole> CreateAsync(DbContext context, long guildId, long roleId)
		{
			var role = (await context.Set<LevelRole>()
				.AddAsync(new LevelRole()
				{
					GuildId = guildId,
					RoleId = roleId
				})).Entity;

			return role;
		}

		public static async Task<LevelRole> GetAsync(DbContext context, long guildId, long roleId)
		{
			LevelRole role = await context.Set<LevelRole>().FindAsync(guildId, roleId);
			if (role == null)
			{
				role = await CreateAsync(context, guildId, roleId);
			}
			return role;
		}
	}
}