using System.Runtime.Serialization;

namespace Miki.Bot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Miki.Bot.Models.Models.User;
    using Miki.Bot.Models.Queries;

    [DataContract]
	public class User
	{
		[DataMember(Order = 1)]
		public long Id { get; set; }

		[DataMember(Order = 2)]
		public string Name { get; set; }

		[DataMember(Order = 3)]
		public string Title { get; set; }

		[DataMember(Order = 4)]
		public int Total_Commands { get; set; }

		[DataMember(Order = 5)]
		public int Total_Experience { get; set; }

		[DataMember(Order = 6)]
		public int Currency { get; set; }

		[DataMember(Order = 7)]
		public int MarriageSlots { get; set; }

		[DataMember(Order = 8)]
		public string AvatarUrl { get; set; }

		[DataMember(Order = 9)]
		public string HeaderUrl { get; set; }

		[DataMember(Order = 10)]
		public DateTime LastDailyTime { get; set; }

		[DataMember(Order = 11)]
		public DateTime DateCreated { get; set; }

		[DataMember(Order = 12)]
		public int Reputation { get; set; }

        [Obsolete]
		public bool Banned { get; set; }

		public List<Achievement> Achievements { get; set; }
		public List<CommandUsage> CommandsUsed { get; set; }
		public List<GlobalPasta> Pastas { get; set; }
		public List<LocalExperience> LocalExperience { get; set; }

        public List<Item> Inventory { get; set; }

		[NotMapped]
		public Connection Connections { get; set; }

		[DataMember(Order = 14)]
		public int DblVotes { get; set; }

		public int Level => CalculateLevel(Total_Experience);

		public static async Task<User> CreateAsync(DbContext context, long id, string name)
		{
			User user = new User()
			{
				Id = id,
				Currency = 0,
				AvatarUrl = "default",
				HeaderUrl = "default",
				LastDailyTime = DateTime.UtcNow.AddDays(-1),
				MarriageSlots = 5,
				Name = name,
				Title = "",
				Total_Commands = 0,
				Total_Experience = 0,
				Reputation = 0,
                DateCreated = DateTime.UtcNow
			};

			await context.Set<User>().AddAsync(user);
			await context.SaveChangesAsync();

			return user;
		}

		public static async Task<User> GetAsync(DbContext context, ulong id, string name)
			=> await GetAsync(context, (long)id, name);

		public static async Task<User> GetAsync(DbContext context, long id, string name)
		{
			var user = await context.Set<User>()
                .FindAsync(id);

			if (user == null)
			{
				return await CreateAsync(context, id, name);
			}
			return user;
		}

		public static async Task<List<User>> SearchUserAsync(DbContext context, string name)
		    => await context.Set<User>()
				.Where(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant())
				.ToListAsync();

		public static int CalculateLevel(int exp)
		    => (int)Math.Sqrt(exp / 10) + 1;
		

        public static int CalculateLevelExperience(int level)
            => level * level * 10;

		public async Task<int> GetGlobalReputationRankAsync(DbContext context)
		    => 1 + await context.Set<User>()
				.Where(u => u.Reputation > Reputation)
				.CountAsync();

		public async Task<int> GetGlobalCommandsRankAsync(DbContext context)
		    => 1 + await context.Set<User>()
				.Where(u => u.Total_Commands > Total_Commands)
				.CountAsync();


		public async Task<int> GetGlobalMekosRankAsync(DbContext context)
		    => 1 + await context.Set<User>()
				.Where(u => u.Currency > Currency)
				.CountAsync();
		

		public async Task<int?> GetGlobalRankAsync(DbContext context)
		{
            var rank = await context.Set<RankObject>()
				.FirstOrDefaultAsync(x => x.Id == Id);
			return rank?.Rank;
		}

		public async Task<bool> IsDonatorAsync(DbContext context)
		{
			IsDonator d = await context.Set<IsDonator>().FindAsync(Id);
			bool b = (d?.ValidUntil ?? new DateTime(0)) > DateTime.Now;
			return b;
		}

        public async Task<bool> IsBannedAsync(DbContext context)
        {
            var ban = await context.Set<IsBanned>()
                .SingleOrDefaultAsync(x => x.UserId == Id && x.ExpirationDate > DateTime.UtcNow);
            return ban != null;
        }
    }

	// TODO: move to own file
	[DataContract]
	public class ReputationObject
	{
		[DataMember(Order = 1)]
		public DateTime LastReputationGiven { get; set; }

		[DataMember(Order = 2)]
		public short ReputationPointsLeft { get; set; }
	}
}