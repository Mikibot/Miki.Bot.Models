﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Miki.Bot.Models.Attributes;

namespace Miki.Bot.Models
{
	[Entity("user")]
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

        [Obsolete("The last claim time is now stored in DailyService.")]
		[DataMember(Order = 10)]
		public DateTime LastDailyTime { get; set; }

		[DataMember(Order = 11)]
		public DateTime DateCreated { get; set; }

		[DataMember(Order = 12)]
		public int Reputation { get; set; }

        [Obsolete]
		public bool Banned { get; set; }
        
        public List<CommandUsage> CommandsUsed { get; set; }
		public List<LocalExperience> LocalExperience { get; set; }


		[DataMember(Order = 14)]
		public int DblVotes { get; set; }

		public int Level => CalculateLevel(Total_Experience);

		public static async Task<User> CreateAsync(DbContext context, long id, string name)
		{
			User user = new User
			{
				Id = id,
				Currency = 0,
				AvatarUrl = "default",
				HeaderUrl = "default",
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

        public static int CalculateLevel(int exp)
		    => (int)Math.Sqrt(exp / 10) + 1;

        public static int CalculateLevelExperience(int level)
            => level * level * 10;
    }
}