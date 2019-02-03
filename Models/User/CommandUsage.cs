using Microsoft.EntityFrameworkCore;
using ProtoBuf;
using System.Threading.Tasks;

namespace Miki.Bot.Models
{
    [ProtoContract]
	public class CommandUsage
	{
		[ProtoMember(1)]
		public long UserId { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public int Amount { get; set; }

		public User User { get; set; }

		public static async Task<CommandUsage> GetAsync(DbContext context, long userId, string name)
		{
			CommandUsage achievement = await context.Set<CommandUsage>().FindAsync(userId, name);

			if (achievement == null)
			{
				achievement = (await context.Set<CommandUsage>()
					.AddAsync(new CommandUsage()
					{
						UserId = userId,
						Amount = 0,
						Name = name
					})).Entity;
				await context.SaveChangesAsync();
			}

			return achievement;
		}
	}
}