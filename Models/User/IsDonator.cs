namespace Miki.Bot.Models
{
    using Microsoft.EntityFrameworkCore;
    using Miki.Bot.Models.Exceptions;
    using System;
    using System.Threading.Tasks;

    public class IsDonator
	{
		public long UserId { get; set; }
        public int TotalPaidCents { get; set; }
		public int CurrentBalance { get; set; }
		public DateTime ValidUntil { get; set; }
		public int KeysRedeemed { get; set; }

		public void AddBalance(int amount)
		{
			if (amount < 0)
			{
				if (CurrentBalance < Math.Abs(amount))
				{
					throw new InsufficientCurrencyException(CurrentBalance, Math.Abs(amount));
				}
			}
			CurrentBalance += amount;
		}

        public static async Task<bool> ForUserAsync(DbContext context, ulong id)
            => await ForUserAsync(context, (long)id);
        public static async Task<bool> ForUserAsync(DbContext context, long id)
        {
            var donator = await context.Set<IsDonator>()
                .AsNoTracking().SingleOrDefaultAsync(x => x.UserId == id);
            if(donator == null)
            {
                return false;
            }
            return donator.ValidUntil > DateTime.UtcNow;
        }
    }
}