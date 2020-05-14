using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Miki.Bot.Models.Models.User
{
    public class IsBanned
    {
        public long BanId { get; set; }
        public long UserId { get; set; }
        public DateTime TimeOfBan { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public static class IsBannedFunctionality
    {
        public static async Task<IsBanned> CreateAsync(this DbSet<IsBanned> context, long userId, TimeSpan duration)
        {
            return (await context.AddAsync(new IsBanned
            {
                UserId = userId,
                TimeOfBan = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow + duration
            })).Entity;
        }

        public static async Task<bool> IsBannedAsync(this DbSet<IsBanned> context, long userId)
        {
            var result = await context.SingleOrDefaultAsync(x => x.UserId == userId && x.ExpirationDate > DateTime.UtcNow);
            return result != null;
        }
    }
}
