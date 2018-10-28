using Microsoft.EntityFrameworkCore;
using Miki.Exceptions;
using ProtoBuf;
using System.Threading.Tasks;

namespace Miki.Models.Objects.Guild
{
	[ProtoContract]
	public class BankAccount
	{
		[ProtoMember(1)]
		public long UserId { get; set; }

		[ProtoMember(2)]
		public long GuildId { get; set; }

		[ProtoMember(3)]
		public long Currency { get; set; }

		[ProtoMember(4)]
		public long TotalDeposited { get; set; }

		public static async Task<BankAccount> GetAsync(DbContext context, ulong userId, ulong guildId)
		{
			return await GetAsync(context, (long)userId, (long)guildId);
		}

		public static async Task<BankAccount> GetAsync(DbContext context, long userId, long guildId)
		{
			var account = await context.Set<BankAccount>()
				.FindAsync(guildId, userId);

			if (account == null)
			{
				account = new BankAccount();
				account.GuildId = guildId;
				account.UserId = userId;
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