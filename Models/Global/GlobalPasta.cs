using Microsoft.EntityFrameworkCore;
using Miki.Bot.Models.Exceptions;
using Miki.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Bot.Models
{
	/// <summary>
	/// Pasta model.
	/// Keeps track all pasta data, transformations and accessors.
	/// </summary>
	public class GlobalPasta
	{
		/// <summary>
		/// The tag of the pasta.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// The content of the pasta.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// The creator their discord Id.
		/// </summary>
		public long CreatorId { get; set; }

		/// <summary>
		/// Time of creation.
		/// </summary>
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Total up- and downvotes.
		/// </summary>
		public int Score { get; set; }

		/// <summary>
		/// Global usage counter.
		/// </summary>
		public int TimesUsed { get; set; }

		/// <summary>
		/// Many to One database connection to User
		/// </summary>
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