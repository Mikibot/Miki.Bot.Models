using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Miki.Bot.Models.Exceptions;
using Miki.Exceptions;
using System.Threading.Tasks;

namespace Miki.Bot.Models
{
	[DataContract]
	public class BankAccount
	{
		[DataMember(Order = 1)]
		public long UserId { get; set; }

		[DataMember(Order = 2)]
		public long GuildId { get; set; }

		[DataMember(Order = 3)]
		public long Currency { get; set; }

		[DataMember(Order = 4)]
		public long TotalDeposited { get; set; }

		public static async Task<BankAccount> GetAsync(DbContext context, ulong userId, ulong guildId)
		{
			return await GetAsync(context, (long)userId, (long)guildId);
		}

		public static async Task<BankAccount> GetAsync(DbContext context, long userId, long guildId)
		{
			var account = await context.Set<BankAccount>()
				.FindAsync(userId, guildId);

			if (account == null)
			{
				account = (await context.Set<BankAccount>().AddAsync(new BankAccount
				{
					GuildId = guildId,
					UserId = userId
				})).Entity;
			}

			return account;
		}

		public void Deposit(int amount)
		{
			Currency += amount;
			TotalDeposited += amount;
		}

		public void Withdraw(int amount)
		{
			if (Currency < amount)
			{
				throw new InsufficientCurrencyException(Currency, amount);
			}
			Currency -= amount;
		}
	}
}