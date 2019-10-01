namespace Miki.Bot.Models.Exceptions
{
    using Miki.Localization;
    using Miki.Localization.Exceptions;
    using Miki.Localization.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DonatorKeyNullException : LocalizedException
    {
        public override IResource LocaleResource => new LanguageResource("error_donatorkey_null");
    }
}
