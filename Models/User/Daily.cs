namespace Miki.Bot.Models
{
    using System.Runtime.Serialization;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using System;
    
    [DataContract]
	public class Daily
	{
		[DataMember(Order = 1)]
		public long UserId { get; set; }

        [DataMember(Order = 2)]
        public int CurrentStreak { get; set; }

        [DataMember(Order = 3)]
        public int LongestStreak { get; set; }

		[DataMember(Order = 4)]
		public DateTime LastClaimTime { get; set; }
    }
}