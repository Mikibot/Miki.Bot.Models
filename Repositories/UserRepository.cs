using Microsoft.EntityFrameworkCore;
using Miki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Miki.Bot.Models.Repositories
{
	public class UserRepository : IAsyncRepository<User>
	{
		private readonly MikiContext _dbContext;
		private readonly DbSet<User> _dbSet;

		public UserRepository(MikiContext context)
		{
			_dbSet = context.Users;
			_dbContext = context;
		}

		public async Task AddAsync(User entity)
		{
			await _dbSet.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<int> CountAsync()
		{
			return await _dbSet.CountAsync();
		}

		public async Task DeleteAsync(User entity)
		{
			_dbSet.Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task EditAsync(User entity)
		{
			_dbSet.Update(entity);
			await _dbContext.SaveChangesAsync();
		}

		public Task<User> GetAsync(params object[] id)
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
