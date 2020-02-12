namespace Miki.Bot.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Threading.Tasks;
    
    [Table("Votes")]
	public class PastaVote
	{
		[Key, Column("Id", Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string Id { get; set; }

		[Key, Column("UserId", Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long UserId { get; set; }

		[Column("PositiveVote")]
		public bool PositiveVote { get; set; }

		public async Task<GlobalPasta> GetParentAsync(DbContext context)
		{
			return await context.Set<GlobalPasta>().FindAsync(Id);
		}
	}
}