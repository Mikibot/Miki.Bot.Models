using System;
using Miki.Localization.Exceptions;
using Miki.Localization;

namespace Miki.Bot.Models.Exceptions
{
    [Obsolete("Use 'EntityNullException<User>' instead.")]
    public class UserNullException : LocalizedException
	{
		public override IResource LocaleResource
			=> new LanguageResource("error_user_null");
	}
}
