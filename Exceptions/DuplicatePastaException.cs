namespace Miki.Bot.Models.Exceptions
{
    using Miki.Exceptions;
    using Miki.Localization;
    using Miki.Bot.Models;
    using Miki.Localization.Models;

    public class DuplicatePastaException : PastaException
	{
		public override IResource LocaleResource
			=> new LanguageResource("miki_module_pasta_create_error_already_exist", $"`{pasta.Id}`");

		public DuplicatePastaException(GlobalPasta pasta) : base(pasta)
		{
		}
	}
}