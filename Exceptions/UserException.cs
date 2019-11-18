
namespace Miki.Bot.Models.Exceptions
{
    using Miki.Localization.Exceptions;
	
    public abstract class UserException : LocalizedException
	{
		protected User User { get; }

        protected UserException(User user)
		{
			User = user;
		}
	}
}