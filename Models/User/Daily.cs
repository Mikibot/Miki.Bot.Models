using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;
using Miki.Logging;

namespace Miki.Bot.Models
{
    [DataContract]
	public class Daily
	{
		[DataMember(Order = 1)]
		public long UserId { get; set; }

        [DataMember(Order = 2)]
        public int CurrentStreak { get; set; }

        [DataMember(Order = 3)]
        public int LongestStreak { get; set; }

		[DataMember(Order = 4)]
		public DateTime LastClaimTime { get; set; }

        public static async Task<Daily> GetAsync(DbContext context, long userId)
        {
            Daily daily = await context.Set<Daily>()
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (daily == null)
            {
                daily = (await context.Set<Daily>()
                    .AddAsync(new Daily()
                    {
                        UserId = userId,
                        LastClaimTime = DateTime.UtcNow.AddHours(-23)
                    })).Entity;
                await context.SaveChangesAsync();
            }

            return daily;
        }
    }
}