﻿using Microsoft.EntityFrameworkCore;

namespace Miki.Bot.Models
{
	public class UserMarriedTo
	{
		public long AskerId { get; set; }
		public long ReceiverId { get; set; }
		public long MarriageId { get; set; }

		public Marriage Marriage { get; set; }

		public ulong GetOther(ulong id)
			=> (ulong)GetOther((long)id);

		public long GetOther(long id)
		{
			return AskerId == id ? ReceiverId : AskerId;
		}

		public void Remove(DbContext context)
		{
			context.Set<UserMarriedTo>().Remove(this);
		}
	}
}