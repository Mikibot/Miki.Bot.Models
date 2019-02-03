using ProtoBuf;
using System;

namespace Miki.Bot.Models
{
	[ProtoContract]
	public class Achievement
	{
		[ProtoMember(1)]
		public long UserId { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public short Rank { get; set; }

		[ProtoMember(4)]
		public DateTime UnlockedAt { get; set; }
	}
}