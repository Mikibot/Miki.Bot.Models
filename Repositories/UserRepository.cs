using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Miki.Bot.Models.Repositories
{
	public class UserRepository : IAsyncRepository<User>
	{
		private readonly DbContext _dbContext;
		private readonly DbSet<User> _dbSet;

		public UserRepository(DbContext context)
		{
			_dbSet = context.Set<User>();
			_dbContext = context;
		}

		public async ValueTask AddAsync(User entity)
		{
			await _dbSet.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<int> CountAsync()
		{
			return await _dbSet.CountAsync();
		}

		public ValueTask DeleteAsync(User entity)
		{
			_dbSet.Remove(entity);
            return default;
		}

		public ValueTask EditAsync(User entity)
		{
			_dbSet.Update(entity);
            return default;
        }

		public ValueTask<User> GetAsync(params object[] id)
		{
			return _dbSet.FindAsync(id);
		}

		public async Task<List<User>> GetLeaderboardsAsync<TKey>(Expression<Func<User, TKey>> sortPredicate, int offset = 0, int amount = 100)
		{
			return await _dbSet.OrderByDescending(sortPredicate)
				.Skip(offset)
				.Take(amount)
				.ToListAsync();
		}
	}
}