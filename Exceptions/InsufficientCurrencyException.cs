using Miki.Localization;
using Miki.Localization.Exceptions;

namespace Miki.Exceptions
{
	internal class InsufficientCurrencyException : LocalizedException
	{
		public override IResource LocaleResource
			=> new LanguageResource("error_insufficient_currency", mekos);

		private long mekos = 0;

		public InsufficientCurrencyException(object currencyOwned, int mekosRequired) : base()
		{
			mekos = mekosRequired - (long)currencyOwned;
		}
	}
}