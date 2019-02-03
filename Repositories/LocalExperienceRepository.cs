using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Miki.Bot.Models.Repositories
{
	public class LocalExperienceRepository : IAsyncRepository<LocalExperience>
	{
		private readonly DbContext _dbContext;
		private readonly DbSet<LocalExperience> _dbSet;

		private readonly long? _guildId;

		public LocalExperienceRepository(DbContext context)
		{
			_dbContext = context;
			_dbSet = context.Set<LocalExperience>();
		}

		public LocalExperienceRepository(DbContext context, long guildId)
			: this(context)
		{
			_guildId = guildId;
		}

		public async Task AddAsync(LocalExperience entity)
		{
			await _dbSet.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<int> CountAsync()
		{
			if (_guildId == null)
			{
				return await _dbSet.CountAsync();
			}
			return await _dbSet.CountAsync(x => x.ServerId == _guildId.Value);
		}

		public async Task DeleteAsync(LocalExperience entity)
		{
			_dbSet.Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task EditAsync(LocalExperience entity)
		{
			_dbSet.Update(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<LocalExperience> GetAsync(params object[] id)
		{
			return await _dbSet.FindAsync(id);
		}
	}
}