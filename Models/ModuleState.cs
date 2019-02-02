using ProtoBuf;

namespace Miki.Bot.Models
{
	[ProtoContract]
	public class ModuleState
	{
		[ProtoMember(1)]
		public string Name { get; set; }

		[ProtoMember(2)]
		public long GuildId { get; set; }

		[ProtoMember(3)]
		public bool State { get; set; }
	}
}