using Microsoft.EntityFrameworkCore;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.Exceptions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Miki.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Total_Commands { get; set; }
        public int Total_Experience { get; set; }
        public int Currency { get; set; }
        public int MarriageSlots { get; set; }
        public string AvatarUrl { get; set; }
		public string HeaderUrl { get; set; }
        public DateTime LastDailyTime { get; set; }

        public DateTime DateCreated { get; set; }
		public int Reputation { get; set; } 
		public bool Banned { get; set; }

		public List<Achievement> Achievements { get; set; }
		public List<CommandUsage> CommandsUsed { get; set; }
		public List<GlobalPasta> Pastas { get; set; }
		public List<LocalExperience> LocalExperience { get; set; }

		[NotMapped]
		public Connection Connections { get; set; }
		
		public int DblVotes { get; set; }

		public int Level => CalculateLevel(Total_Experience);

		public static async Task<User> CreateAsync(long id, string name)
		{
			using (var context = new MikiContext())
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

				await context.Users.AddAsync(user);
				await context.SaveChangesAsync();

				return user;
			}
		}

		public static async Task<User> GetAsync(MikiContext context, ulong id, string name)
			=> await GetAsync(context, id, name);
		public static async Task<User> GetAsync(MikiContext context, long id, string name)
		{
			User user = null;

			user = await context.Users.FindAsync(id);

			if(user == null)
			{
				return await CreateAsync(id, name);
			}
			return user;
		}

		public static async Task<List<User>> SearchUserAsync(MikiContext context, string name)
		{
			return await context.Users
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

		public async Task<int> GetGlobalReputationRankAsync()
		{
			int x = 0;
			using (var context = new MikiContext())
			{
				x = await context.Users
					.Where(u => u.Reputation > Reputation)
					.CountAsync();
			}
			return x + 1;
		}

		public async Task<int> GetGlobalCommandsRankAsync()
		{
			int x = 0;
			using (var context = new MikiContext())
			{
				x = await context.Users
					.Where(u => u.Total_Commands > Total_Commands)
					.CountAsync();
			}
			return x + 1;
		}

		public async Task<int> GetGlobalMekosRankAsync()
		{
			int x = 0;
			using (var context = new MikiContext())
			{
				x = await context.Users
					.Where(u => u.Currency > Currency)
					.CountAsync();
			}
			return x + 1;
		}

        public async Task<int> GetGlobalRankAsync()
        {
            int x = 0;
            using (var context = new MikiContext())
            {
                x = await context.Users
                    .Where(u => u.Total_Experience > Total_Experience)
                    .CountAsync();
            }
            return x + 1;
        }

		public async Task<bool> IsDonatorAsync(MikiContext context)
		{
			IsDonator d = await context.IsDonator.FindAsync(Id);
			bool b = (d?.ValidUntil ?? new DateTime(0)) > DateTime.Now;
			return b;
		}

		private static int CalculateNextLevelIteration(int output, int level)
		{
			return 10 + (output + (level * 20));
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