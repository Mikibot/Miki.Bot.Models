using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Miki.Models.User
{
    public enum UserAction
    {
        ACHIEVEMENT_GAIN,
        DIVORCE,
        MARRIAGE_ACCEPT,
        MARRIAGE_CANCEL,
        MARRIAGE_DECLINE,
        MARRIAGE_PROPOSE,
        TRANSACTION_RECEIVE,
        TRANSACTION_SEND,
    }

    public struct UserLogTransaction
    {
        [DataMember(Name = "amount")]
        public int Amount { get; set; }
    }

    public class UserLog
    {
        [DataMember(Name = "log_id")]
        public long LogId { get; set; }

        [DataMember(Name = "user_id")]
        public long UserId { get; set; }

        [DataMember(Name = "action")]
        public UserAction Action { get; set; }

        [DataMember(Name = "data")]
        public string Context { get; set; }

        [DataMember(Name = "timestamp")]
        public DateTime Time { get; set; }
    }
}
