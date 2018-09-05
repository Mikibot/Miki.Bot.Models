using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Miki.Models
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

		public static async Task<CommandUsage> GetAsync(MikiContext context, long userId, string name)
		{
			CommandUsage achievement = await context.CommandUsages.FindAsync(userId, name);

			if (achievement == null)
			{
				achievement = (await context.CommandUsages.AddAsync(new CommandUsage()
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