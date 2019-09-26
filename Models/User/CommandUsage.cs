using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Miki.Bot.Models
{
    [DataContract]
	public class CommandUsage
	{
		[DataMember(Order = 1)]
		public long UserId { get; set; }

		[DataMember(Order = 2)]
		public string Name { get; set; }

		[DataMember(Order = 3)]
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