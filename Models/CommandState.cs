using ProtoBuf;

namespace Miki.Framework.Models
{
	[ProtoContract]
	public class CommandState
	{
		[ProtoMember(1)]
		public string Name { get; set; }

		[ProtoMember(2)]
		public long ChannelId { get; set; }

		[ProtoMember(3)]
		public bool State { get; set; }

		[ProtoMember(4)]
		public long GuildId { get; set; }
	}
}