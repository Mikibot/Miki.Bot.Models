﻿using System;

namespace Miki.Bot.Models
{
	public class Marriage
	{
		public long MarriageId { get; set; }
		public UserMarriedTo Participants { get; set; }
		public bool IsProposing { get; set; }
		public DateTime TimeOfMarriage { get; set; }
		public DateTime TimeOfProposal { get; set; }

		public ulong GetOther(ulong id)
			=> (ulong)GetOther((long)id);

		public long GetOther(long id)
		{
			return Participants.AskerId == id ? Participants.ReceiverId : Participants.AskerId;
		}
	}
}