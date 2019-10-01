namespace Miki.Bot.Models.Exceptions
{
    using Miki.Localization.Exceptions;
    using Miki.Localization.Models;

    public class ArgumentLessThanZeroException : LocalizedException
	{
		public override IResource LocaleResource => new LanguageResource("error_argument_less_than_zero");
	}
}
