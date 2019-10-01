using Miki.Localization;
using Miki.Localization.Exceptions;
using Miki.Localization.Models;

namespace Miki.Bot.Models.Exceptions
{
	public class InsufficientCurrencyException : LocalizedException
	{
		public override IResource LocaleResource
			=> new LanguageResource("error_insufficient_currency", mekos.ToString("N0"));

		private readonly long mekos = 0;

		public InsufficientCurrencyException(long currencyOwned, long mekosRequired) : base()
		{
			mekos = mekosRequired - currencyOwned;
		}
	}
}