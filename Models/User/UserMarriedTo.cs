using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Miki.Bot.Models
{
	public class UserMarriedTo
	{
        /// <summary>
        /// The creator of the proposal.
        /// </summary>
		public long AskerId { get; set; }

        /// <summary>
        /// The receiver of the proposal.
        /// </summary>
        public long ReceiverId { get; set; }

        /// <summary>
        /// Composite key to the Marriage instance.
        /// </summary>
        public long MarriageId { get; set; }

		public Marriage Marriage { get; set; }

        public static async Task<UserMarriedTo> CreateAsync(DbContext context, long askerId, long receiverId)
        {
            var marriage = await context.Set<Marriage>()
                 .AddAsync(new Marriage { IsProposing = true, TimeOfMarriage = DateTime.UtcNow, TimeOfProposal = DateTime.UtcNow });

            var userMarriedTo = await context.Set<UserMarriedTo>()
                .AddAsync(new UserMarriedTo { AskerId = askerId, ReceiverId = receiverId, MarriageId = marriage.Entity.MarriageId });

            return userMarriedTo.Entity;
        }

		public ulong GetOther(ulong id)
			=> (ulong)GetOther((long)id);

		public long GetOther(long id)
		{
			return AskerId == id ? ReceiverId : AskerId;
		}

		public void Remove(DbContext context)
		{
			context.Set<UserMarriedTo>()
                .Remove(this);
		}
	}
}