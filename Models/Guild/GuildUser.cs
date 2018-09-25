using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Models
{
	[Table("GuildUsers")]
	public class GuildUser
	{
		[Key, Column("EntityId", Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }

		public string Name { get; set; }

		public long Currency { get; set; } = 0;

		public int Experience { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long RivalId { get; set; }

		public int UserCount { get; set; }

		public DateTime LastRivalRenewed { get; set; }

		[Column("banned")]
		public bool Banned { get; set; } = false;

		#region Config

		public int MinimalExperienceToGetRewards { get; set; }
		public bool VisibleOnLeaderboards { get; set; } = true;

		#endregion Config

		public int CalculateLevel(int exp)
		{
			int experience = exp;
			int Level = 0;
			int output = 0;
			while (experience >= output)
			{
				output = CalculateNextLevelIteration(output, Level);
				Level++;
			}
			return Level;
		}

		public int CalculateMaxExperience(int localExp)
		{
			int experience = localExp;
			int Level = 0;
			int output = 0;
			while (experience >= output)
			{
				output = CalculateNextLevelIteration(output, Level);
				Level++;
			}
			return output;
		}

		private int CalculateNextLevelIteration(int output, int level)
		{
			return 10 + (output + (level * 20));
		}

		public int GetGlobalRank(DbContext context)
		{
			int rank = context.Set<GuildUser>()
				.Where(x => x.Experience > Experience)
				.Count();
			return rank;
		}

		public async Task<GuildUser> GetRival(DbContext context)
		{
			if (RivalId == 0)
			{
				return null;
			}

			return await context.Set<GuildUser>()
				.FindAsync(RivalId);
		}
	}
}