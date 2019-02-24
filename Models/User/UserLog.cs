using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.Bot.Models.Models.User
{
    public enum UserAction
    {
        ACHIEVEMENT_GAIN,
        MARRIAGE_PROPOSE,
        MARRIAGE_DECLINE,
        MARRIAGE_CANCEL,
        MARRIAGE_ACCEPT,
        DIVORCE,
        TRANSACTION_RECEIVE,
        TRANSACTION_SEND,
    }

    public class UserLog
    {
        public long UserId { get; set; }

        public UserAction Action { get; set; }

        public string Context { get; set; }

        public DateTime Time { get; set; }
    }
}
