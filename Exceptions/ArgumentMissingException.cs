namespace Miki.Bot.Models.Exceptions
{
    using Miki.Localization.Exceptions;
    using Miki.Localization.Models;

    public class ArgumentMissingException : LocalizedException
    {
        private readonly string argumentName;

        /// <inheritdoc />
        public override IResource LocaleResource
            => new LanguageResource("errors_missing_argument", argumentName);

        public ArgumentMissingException(string argumentName)
        {
            this.argumentName = argumentName;
        }
    }
}
