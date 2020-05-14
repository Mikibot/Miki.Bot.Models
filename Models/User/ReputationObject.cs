using System;
using System.Runtime.Serialization;

namespace Miki.Bot.Models
{
    [DataContract]
    public class ReputationObject
    {
        [DataMember(Order = 1)]
        public DateTime LastReputationGiven { get; set; }

        [DataMember(Order = 2)]
        public short ReputationPointsLeft { get; set; }
    }
}