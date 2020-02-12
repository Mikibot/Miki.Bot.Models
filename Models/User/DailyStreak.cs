using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Miki.Bot.Models
{
    [DataContract]
	public class DailyStreak
	{
		[DataMember(Order = 1)]
		public long UserId { get; set; }

		[DataMember(Order = 2)]
		public long CurrentStreak { get; set; }

		[DataMember(Order = 3)]
		public DateTime LastStreakTime { get; set; }

        public static async Task<DailyStreak> GetAsync(DbContext context, long userId)
        {
            DailyStreak streak = await context.Set<DailyStreak>()
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (streak == null)
            {
                streak = (await context.Set<DailyStreak>()
                    .AddAsync(new DailyStreak()
                    {
                        UserId = userId,
                        CurrentStreak = 0,
                        LastStreakTime = DateTime.UtcNow.AddHours(-23)
                    })).Entity;
                await context.SaveChangesAsync();
            }

            return streak;
        }
    }
}