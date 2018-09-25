using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Miki.Models
{
	public class Marriage
	{
		public long MarriageId { get; set; }
		public UserMarriedTo Participants { get; set; }
		public bool IsProposing { get; set; }
		public DateTime TimeOfMarriage { get; set; }
		public DateTime TimeOfProposal { get; set; }

		public void AcceptProposal()
		{
			TimeOfMarriage = DateTime.Now;
			IsProposing = false;
		}

		public ulong GetOther(ulong id)
			=> (ulong)GetOther((long)id);
		public long GetOther(long id)
		{
			return Participants.AskerId == id ? Participants.ReceiverId : Participants.AskerId;
		}
	}
}