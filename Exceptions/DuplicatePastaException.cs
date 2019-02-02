using Miki.Exceptions;
using Miki.Localization;
using Miki.Bot.Models;
using Miki.Models;

namespace Miki.Bot.Models.Exceptions
{
	public class DuplicatePastaException : PastaException
	{
		public override IResource LocaleResource
			=> new LanguageResource("miki_module_pasta_create_error_already_exist", $"`{pasta.Id}`");

		public DuplicatePastaException(GlobalPasta pasta) : base(pasta)
		{
		}
	}
}