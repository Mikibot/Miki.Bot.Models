using Miki.Localization;
using Miki.Localization.Exceptions;
using Miki.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
