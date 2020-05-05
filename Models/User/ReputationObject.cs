namespace Miki.Bot.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class ReputationObject
    {
        [DataMember(Order = 1)]
        public DateTime LastReputationGiven { get; set; }

        [DataMember(Order = 2)]
        public short ReputationPointsLeft { get; set; }
    }
}