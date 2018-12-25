using Miki.Localization;
using Miki.Localization.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.Bot.Models.Exceptions
{
	public class UserNullException : LocalizedException
	{
		public override IResource LocaleResource
			=> new LanguageResource("error_user_null");
	}
}
