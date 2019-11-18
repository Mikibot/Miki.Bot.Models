namespace Miki.Bot.Models.Exceptions
{
    using Miki.Bot.Models;
    using Miki.Localization.Models;

    public class UserBannedException : UserException
    {
        public override IResource LocaleResource 
            => new LanguageResource("error_user_banned");

        public UserBannedException(User user)
            : base(user)
        {
        }
    }
}