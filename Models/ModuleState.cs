namespace Miki.Bot.Models
{
    using System.Runtime.Serialization;

    [DataContract]
	public class ModuleState
	{
		[DataMember(Order = 1)]
		public string Name { get; set; }

		[DataMember(Order = 2)]
		public long GuildId { get; set; }

		[DataMember(Order = 3)]
		public bool State { get; set; }
	}
}