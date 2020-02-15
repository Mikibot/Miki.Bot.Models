namespace Miki.Bot.Models
{
	using Microsoft.EntityFrameworkCore;
	using Miki.Bot.Models.Exceptions;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.Threading.Tasks;

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

		public int GuildHouseLevel { get; set; }

		public float GuildHouseMultiplier => GuildHouseRates[GuildHouseLevel];
		public long GuildHouseUpgradePrice => GuildHousePrices?[GuildHouseLevel] ?? -1L;

		[Column("banned")]
		public bool Banned { get; set; } = false;

		#region Config
        public int MinimalExperienceToGetRewards { get; set; }
		public bool VisibleOnLeaderboards { get; set; } = true;
        #endregion Config

		private readonly long[] GuildHousePrices = {
			10000, 50000, 200000, 800000, 2000000, 8000000, 20000000,
			100000000, 1000000000, 5000000000, 15000000000
		};

        private readonly float[] GuildHouseRates = {
			1f, 1.5f, 2f, 2.4f, 2.8f, 3.1f, 3.4f, 3.7f, 4f, 4.2f, 4.4f, 4.6f
		};

		public void AddCurrency(long amount)
		{
			if(amount < 0)
			{
				throw new ArgumentLessThanZeroException();
			}

			Currency += amount;
		}

		public int CalculateLevel(int exp)
		{
			int experience = exp;
			int level = 0;
			int output = 0;
			while (experience >= output)
			{
				output = CalculateNextLevelIteration(output, level);
				level++;
			}
			return level;
		}

		public int CalculateMaxExperience(int localExp)
		{
			int experience = localExp;
			int level = 0;
			int output = 0;
			while (experience >= output)
			{
				output = CalculateNextLevelIteration(output, level);
				level++;
			}
			return output;
		}

		private int CalculateNextLevelIteration(int output, int level)
		{
			return 10 + (output + (level * 20));
		}

		public void RemoveCurrency(long amount)
		{
			if(amount < 0)
			{
				throw new ArgumentLessThanZeroException();
			}

			if(amount > Currency)
			{
				throw new InsufficientCurrencyException(Currency, amount);
			}

			Currency -= amount;
		}

		public async Task<int> GetGlobalRankAsync(DbContext context)
			=> await context.Set<GuildUser>()
				.Where(x => x.Experience > Experience)
				.CountAsync();

		public async Task<GuildUser> GetRivalOrDefaultAsync(DbContext context)
		{
			if (RivalId == 0)
			{
				return null;
			}

			return await context.Set<GuildUser>()
				.FindAsync(RivalId);
		}

		/// <summary>
		/// Gets the guild rival or throws an exception if not found!
		/// </summary>
		/// <param name="context">A Database context which holds your guildUser data</param>
		/// <returns>GuildUser</returns>
		public async Task<GuildUser> GetRivalAsync(DbContext context)
			=> await GetRivalOrDefaultAsync(context)
				?? throw new GuildRivalNullException();
	}
}