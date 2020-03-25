namespace Miki.Bot.Models.Exceptions
{
    using Miki.Localization.Exceptions;
    using Miki.Localization;
    using System;
    
    class GuildRivalNullException : LocalizedException
	{
		public override IResource LocaleResource 
			=> new LanguageResource("guildweekly_error_no_rival");
	}
}
