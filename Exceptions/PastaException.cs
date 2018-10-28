using Miki.Localization.Exceptions;
using Miki.Models;

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