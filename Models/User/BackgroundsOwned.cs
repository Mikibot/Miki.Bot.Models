using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Miki.Models
{
	public class BackgroundsOwned
	{
		public long UserId { get; set; }
		public int BackgroundId { get; set; }

		public static Task<BackgroundsOwned> GetAsync(ulong userId, int backgroundId, DbContext context)
			=> GetAsync((long)userId, backgroundId, context);

		public static async Task<BackgroundsOwned> GetAsync(long userId, int backgroundId, DbContext context)
		{
			var bg = await context.Set<BackgroundsOwned>()
				.FindAsync(userId, backgroundId);

			if (bg == null)
			{
				return (await context.Set<BackgroundsOwned>()
					.AddAsync(new BackgroundsOwned() { UserId = userId, BackgroundId = backgroundId })).Entity;
			}

			return bg;
		}
	}
}