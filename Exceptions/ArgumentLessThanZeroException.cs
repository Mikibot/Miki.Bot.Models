using Miki.Localization.Exceptions;
using Miki.Localization;

namespace Miki.Bot.Models.Exceptions
{
    public class ArgumentLessThanZeroException : LocalizedException
    {
        public override IResource LocaleResource => new LanguageResource("error_argument_less_than_zero");
    }
}