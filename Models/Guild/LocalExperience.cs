namespace Miki.Bot.Models
{
	using Microsoft.EntityFrameworkCore;
	using System.Linq;
	using System.Threading.Tasks;

	public class LocalExperience
	{
		public long ServerId { get; set; }
		public long UserId { get; set; }
		public int Experience { get; set; }

        public User User { get; set; }

        public static Task<LocalExperience> CreateAsync(DbContext context, ulong guildId, ulong userId, string name)
            => CreateAsync(context, (long)guildId, (long)userId, name);
		public static async Task<LocalExperience> CreateAsync(DbContext context, long guildId, long userId, string name)
		{
            // TODO: check if local user already exists

            var experience = new LocalExperience
            {
                ServerId = guildId,
                UserId = userId,
                Experience = 0
            };

            experience = (await context
                .Set<LocalExperience>()
                .AddAsync(experience)).Entity;
            
			if (!await context
                .Set<User>()
                .AnyAsync(x => x.Id == userId))
			{
				await User.CreateAsync(context, userId, name);
			}
			await context.SaveChangesAsync();
			return experience;
		}

		public static Task<LocalExperience> GetAsync(DbContext context, ulong guildId, ulong userId)
			=> GetAsync(context, (long)guildId, (long)userId);
		public static async Task<LocalExperience> GetAsync(DbContext context, long serverId, long userId)
		{
			var localExperience = await context
                .Set<LocalExperience>()
                .FindAsync(serverId, userId);
			return localExperience;
		}

		public async Task<int> GetRankAsync(DbContext context)
		{
			int x = await context.Set<LocalExperience>()
				.Where(e => e.ServerId == ServerId && e.Experience > Experience)
				.CountAsync();
			return x + 1;
		}
	}
}