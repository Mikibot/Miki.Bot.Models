using System;
using Miki.Localization.Exceptions;
using Miki.Localization;

namespace Miki.Bot.Models.Exceptions
{
    [Obsolete("Use 'EntityNullException<DonatorKey>' instead.")]
    public class DonatorKeyNullException : LocalizedException
    {
        public override IResource LocaleResource => new LanguageResource("error_donatorkey_null");
    }
}