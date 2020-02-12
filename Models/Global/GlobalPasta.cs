namespace Miki.Bot.Models
{
    using Microsoft.EntityFrameworkCore;
    using Miki.Bot.Models.Exceptions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    
    
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
	}

	public class PastaSearchResult
	{
		public string Id { get; set; }
		public int Count { get; set; }
	}
}