namespace Miki.Bot.Models.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Miki.Patterns.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class UserRepository : IAsyncRepository<User>
	{
		private readonly DbSet<User> set;

		public UserRepository(DbContext context)
		{
			set = context.Set<User>();
		}

		public ValueTask AddAsync(User entity)
		{
			set.Add(entity);
            return default;
		}

		public ValueTask DeleteAsync(User entity)
		{
			set.Remove(entity);
            return default;
		}

		public ValueTask EditAsync(User entity)
		{
			set.Update(entity);
            return default;
        }

		public ValueTask<User> GetAsync(params object[] id)
		{
			return set.FindAsync(id);
		}

		public async Task<List<User>> GetLeaderboardsAsync<TKey>(Expression<Func<User, TKey>> sortPredicate, int offset = 0, int amount = 100)
		{
			return await set.OrderByDescending(sortPredicate)
				.Skip(offset)
				.Take(amount)
				.ToListAsync();
		}

        public ValueTask<IEnumerable<User>> ListAsync()
        {
            return new ValueTask<IEnumerable<User>>(set);
        }
    }
}