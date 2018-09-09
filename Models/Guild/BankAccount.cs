using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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

		public static async Task<BankAccount> GetAsync(MikiContext context, ulong userId, ulong guildId)
		{
			return await context.BankAccounts.FindAsync(guildId, userId);
		}
    }
}
