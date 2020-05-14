using Miki.Localization.Exceptions;

namespace Miki.Bot.Models.Exceptions
{
    public abstract class UserException : LocalizedException
	{
		protected User User { get; }

        protected UserException(User user)
		{
			User = user;
		}
	}
}