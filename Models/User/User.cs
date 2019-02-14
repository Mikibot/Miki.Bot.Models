using Microsoft.EntityFrameworkCore;
using Miki.Bot.Models.Queries;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Bot.Models
{
    [ProtoContract]
	public class User
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public string Title { get; set; }

		[ProtoMember(4)]
		public int Total_Commands { get; set; }

		[ProtoMember(5)]
		public int Total_Experience { get; set; }

		[ProtoMember(6)]
		public int Currency { get; set; }

		[ProtoMember(7)]
		public int MarriageSlots { get; set; }

		[ProtoMember(8)]
		public string AvatarUrl { get; set; }

		[ProtoMember(9)]
		public string HeaderUrl { get; set; }

		[ProtoMember(10)]
		public DateTime LastDailyTime { get; set; }

		[ProtoMember(11)]
		public DateTime DateCreated { get; set; }

		[ProtoMember(12)]
		public int Reputation { get; set; }

		[ProtoMember(13)]
		public bool Banned { get; set; }

		public List<Achievement> Achievements { get; set; }
		public List<CommandUsage> CommandsUsed { get; set; }
		public List<GlobalPasta> Pastas { get; set; }
		public List<LocalExperience> LocalExperience { get; set; }

		[NotMapped]
		public Connection Connections { get; set; }

		[ProtoMember(14)]
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
				LastDailyTime = DateTime.UtcNow - TimeSpan.FromDays(1),
				MarriageSlots = 5,
				Name = name,
				Title = "",
				Total_Commands = 0,
				Total_Experience = 0,
				Reputation = 0
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
		{
			return await context.Set<User>()
				.Where(x => x.Name.ToLower() == name.ToLower())
				.ToListAsync();
		}

		public static int CalculateLevel(int exp)
		{
			return (int)Math.Sqrt(exp / 10) + 1;
		}

		public static int CalculateLevelExperience(int level)
		{
			return (level * level * 10);
		}

		public async Task<int> GetGlobalReputationRankAsync(DbContext context)
		{
			int x = 0;

			x = await context.Set<User>()
				.Where(u => u.Reputation > Reputation)
				.CountAsync();

			return x + 1;
		}

		public async Task<int> GetGlobalCommandsRankAsync(DbContext context)
		{
			int x = 0;

			x = await context.Set<User>()
				.Where(u => u.Total_Commands > Total_Commands)
				.CountAsync();

			return x + 1;
		}

		public async Task<int> GetGlobalMekosRankAsync(DbContext context)
		{
			int x = 0;

			x = await context.Set<User>()
				.Where(u => u.Currency > Currency)
				.CountAsync();

			return x + 1;
		}

		public async Task<int?> GetGlobalRankAsync(DbContext context)
		{
			var rank = await context.Query<RankObject>()
				.FirstOrDefaultAsync(x => x.Id == Id);
			return rank?.Rank;
		}

		public async Task<bool> IsDonatorAsync(DbContext context)
		{
			IsDonator d = await context.Set<IsDonator>().FindAsync(Id);
			bool b = (d?.ValidUntil ?? new DateTime(0)) > DateTime.Now;
			return b;
		}
	}

	// TODO: move to own file
	[ProtoContract]
	public class ReputationObject
	{
		[ProtoMember(1)]
		public DateTime LastReputationGiven { get; set; }

		[ProtoMember(2)]
		public short ReputationPointsLeft { get; set; }
	}
}