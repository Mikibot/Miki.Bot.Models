using Miki.Bot.Models;
using Miki.Localization.Exceptions;

namespace Miki.Exceptions
{
	public abstract class PastaException : LocalizedException
	{
		protected GlobalPasta pasta;

		public PastaException(GlobalPasta pasta) : base()
		{
			this.pasta = pasta;
		}
	}
}