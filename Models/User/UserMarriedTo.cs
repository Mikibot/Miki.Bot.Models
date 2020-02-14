namespace Miki.Bot.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

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

		public ulong GetOther(ulong id)
			=> (ulong)GetOther((long)id);

		public long GetOther(long id)
		{
			return AskerId == id ? ReceiverId : AskerId;
		}
    }
}