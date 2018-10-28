using Microsoft.EntityFrameworkCore;
using Miki.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Models
{
	public class GlobalPasta
	{
		public string Id { get; set; }
		public string Text { get; set; }
		public long CreatorId { get; set; }
		public DateTime CreatedAt { get; set; }
		public int Score { get; set; }
		public int TimesUsed { get; set; }

		public User User { get; set; }

		public static async Task AddAsync(DbContext context, string id, string text, long creator)
		{
			GlobalPasta pasta = await context.Set<GlobalPasta>()
				.FindAsync(id);

			if (pasta != null)
			{
				throw new DuplicatePastaException(pasta);
			}

			await context.Set<GlobalPasta>()
				.AddAsync(new GlobalPasta()
				{
					Id = id,
					Text = text,
					CreatorId = creator,
					CreatedAt = DateTime.Now
				});
		}

		public async Task<int> GetScoreAsync(DbContext context)
		{
			var votes = await GetVotesAsync(context);
			return votes.Upvotes - votes.Downvotes;
		}

		public async Task<VoteCount> GetVotesAsync(DbContext context)
		{
			VoteCount c = new VoteCount();
			c.Upvotes = await context.Set<PastaVote>()
				.Where(x => x.Id == Id && x.PositiveVote == true)
				.CountAsync();
			c.Downvotes = await context.Set<PastaVote>()
				.Where(x => x.Id == Id && x.PositiveVote == false)
				.CountAsync();
			return c;
		}
	}

	public class PastaSearchResult
	{
		public string Id { get; set; }
		public int Count { get; set; }
	}
}