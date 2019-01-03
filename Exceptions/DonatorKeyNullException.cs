using Miki.Localization;
using Miki.Localization.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.Bot.Models.Exceptions
{
    public class DonatorKeyNullException : LocalizedException
    {
        public override IResource LocaleResource => new LanguageResource("error_donatorkey_null");
    }
}
