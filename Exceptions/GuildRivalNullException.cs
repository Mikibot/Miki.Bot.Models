using Miki.Localization;
using Miki.Localization.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.Bot.Models.Exceptions
{
	class GuildRivalNullException : LocalizedException
	{
		public override IResource LocaleResource 
			=> new LanguageResource("guildweekly_error_no_rival");
	}
}
