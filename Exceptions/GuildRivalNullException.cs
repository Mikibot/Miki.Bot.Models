namespace Miki.Bot.Models.Exceptions
{
    using Miki.Localization;
    using Miki.Localization.Exceptions;
    using Miki.Localization.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class GuildRivalNullException : LocalizedException
	{
		public override IResource LocaleResource 
			=> new LanguageResource("guildweekly_error_no_rival");
	}
}
