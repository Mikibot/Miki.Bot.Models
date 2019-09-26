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

		public ValueTask AddAsync(LocalExperience entity)
		{
			_dbSet.Add(entity);
            return default;
        }

		public async Task<int> CountAsync()
		{
			if (_guildId == null)
			{
				return await _dbSet.CountAsync();
			}
			return await _dbSet.CountAsync(x => x.ServerId == _guildId.Value);
		}

		public ValueTask DeleteAsync(LocalExperience entity)
		{
			_dbSet.Remove(entity);
            return default;
        }

		public ValueTask EditAsync(LocalExperience entity)
		{
			_dbSet.Update(entity);
            return default;
		}

		public async ValueTask<LocalExperience> GetAsync(params object[] id)
		{
			return await _dbSet.FindAsync(id);
		}
	}
}