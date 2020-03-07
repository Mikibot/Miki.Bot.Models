namespace Miki.Bot.Models.Exceptions
{
    using Miki.Localization.Exceptions;
    using Miki.Localization.Models;

    public class DonatorKeyNullException : LocalizedException
    {
        public override IResource LocaleResource => new LanguageResource("error_donatorkey_null");
    }
}