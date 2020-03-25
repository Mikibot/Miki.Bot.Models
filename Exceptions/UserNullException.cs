namespace Miki.Bot.Models.Exceptions
{
    using System;
    using Miki.Localization.Exceptions;
    using Miki.Localization;

    [Obsolete("Use 'EntityNullException<User>' instead.")]
    public class UserNullException : LocalizedException
	{
		public override IResource LocaleResource
			=> new LanguageResource("error_user_null");
	}
}
