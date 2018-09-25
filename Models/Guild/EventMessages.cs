using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Miki.Models
{
    // TODO: add more event types
    public enum EventMessageType
    {
        JOINSERVER = 0,
        LEAVESERVER = 1,
    }

    [Table("EventMessages")]
    public class EventMessage
    {
		static Dictionary<Tuple<long, short>, string> eventMessages = new Dictionary<Tuple<long, short>, string>();

        [Key]
        [Column("ChannelId", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ChannelId { get; set; }

        [Key]
        [Column("EventType", Order = 1)]
        public short EventType { get; set; }

        [Column("Message")]
        public string Message { get; set; }

		public static async Task<string> GetAsync(DbContext context, long channelId, short eventType)
		{
			if (eventMessages.TryGetValue(new Tuple<long, short>(channelId, eventType), out string x))
			{
				return x;
			}
			else
			{
				var eventMsg = await context.Set<EventMessage>()
					.FindAsync(channelId, eventType);

				if (eventMsg != null)
				{
					eventMessages.Add(new Tuple<long, short>(channelId, eventType), eventMsg.Message);
				}

				return eventMsg.Message;
			}
		}
	}
}