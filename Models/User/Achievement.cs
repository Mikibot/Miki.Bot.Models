using System;
using System.Runtime.Serialization;

namespace Miki.Bot.Models
{
	[DataContract]
	public class Achievement
	{
		[DataMember(Order = 1)]
		public long UserId { get; set; }

		[DataMember(Order = 2)]
		public string Name { get; set; }

		[DataMember(Order = 3)]
		public short Rank { get; set; }

		[DataMember(Order = 4)]
		public DateTime UnlockedAt { get; set; }
	}
}