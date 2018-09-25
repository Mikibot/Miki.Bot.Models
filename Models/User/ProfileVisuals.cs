using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Miki.Models.Objects.User
{
    public class ProfileVisuals
    {
		public long UserId { get; set; }
		public int BackgroundId { get; set; } = 0;
		public string ForegroundColor { get; set; } = "#000000";
		public string BackgroundColor { get; set; } = "#000000";

		public static async Task<ProfileVisuals> GetAsync(ulong userId, DbContext context)
			=> await GetAsync((long)userId, context);
		public static async Task<ProfileVisuals> GetAsync(long userId, DbContext context)
		{
			ProfileVisuals visuals = await context.Set<ProfileVisuals>().FindAsync(userId);

			if (visuals == null)
			{
				visuals = (await context.Set<ProfileVisuals>()
					.AddAsync(new ProfileVisuals() { UserId = userId })).Entity;
			}

			return visuals;
		}
	}
}
