using Miki.Exceptions;
using System;

namespace Miki.Models
{
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
	}
}