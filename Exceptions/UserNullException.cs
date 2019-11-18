namespace Miki.Bot.Models.Exceptions
{
    using Miki.Localization.Exceptions;
    using Miki.Localization.Models;
    
    public class UserNullException : LocalizedException
	{
		public override IResource LocaleResource
			=> new LanguageResource("error_user_null");
	}
}
