using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Models
{
    public class LocalExperience
    {
        public long ServerId { get; set; }
        public long UserId { get; set; }
        public int Experience { get; set; }

		public User User { get; set; }

		public static async Task<LocalExperience> CreateAsync(DbContext context, long ServerId, long userId, string name)
        {
            LocalExperience experience = null;

            experience = new LocalExperience();
            experience.ServerId = ServerId;
            experience.UserId = userId;
            experience.Experience = 0;

			experience = (await context.Set<LocalExperience>().AddAsync(experience)).Entity;

			if (await context.Set<User>().FindAsync(userId) == null)
			{
				await User.CreateAsync(context, userId, name);
			}

            await context.SaveChangesAsync();

            return experience;
        }

		public static async Task<LocalExperience> GetAsync(DbContext context, ulong guildId, ulong userId, string name)
			=> await GetAsync(context, (long)guildId, (long)userId, name);
		public static async Task<LocalExperience> GetAsync(DbContext context, long serverId, long userId, string name)
		{
			var localExperience = await context.Set<LocalExperience>().FindAsync(serverId, userId);
			if (localExperience == null)
			{
				return await CreateAsync(context, serverId, userId, name);
			}
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