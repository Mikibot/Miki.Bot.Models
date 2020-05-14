using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.Framework;
using Microsoft.EntityFrameworkCore;
using Miki.Patterns.Repositories;

namespace Miki.Bot.Models.Repositories
{
    public class AchievementRepository : IAsyncRepository<Achievement>
    {
        private readonly DbSet<Achievement> set;

        public class Factory : IRepositoryFactory<Achievement>
        {
            /// <inheritdoc />
            public IAsyncRepository<Achievement> Build(DbContext context)
            {
                return new AchievementRepository(context);
            }
        }

        public AchievementRepository(DbContext ctx)
        {
            set = ctx.Set<Achievement>();
        }

        public ValueTask<Achievement> GetAsync(long userId, string name)
        {
            return new ValueTask<Achievement>(
                set.Where(x => x.Name == name
                            && x.UserId == userId)
                .OrderByDescending(x => x.Rank)
                .FirstOrDefaultAsync());
        }
        public ValueTask<Achievement> GetAsync(params object[] id)
        {
            if (id.Length != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            return GetAsync((long)id[0], (string)id[1]);
        }

        public async ValueTask<Achievement> AddAsync(Achievement entity)
        {
            var entry = await set.AddAsync(entity);
            return entry.Entity;
        }

        public async ValueTask EditAsync(Achievement entity)
        {
            var achievement = await GetAsync(entity.UserId, entity.Name);
            if (achievement == null)
            {
                throw new InvalidOperationException("Can not edit Achievement that is null");
            }
            set.Update(entity);
        }

        public ValueTask DeleteAsync(Achievement entity)
        {
            set.Remove(entity);
            return default;
        }

        public async Task<IReadOnlyList<Achievement>> ListAsync(long userId)
        {
            return await set.Where(x => x.UserId == userId)
                .GroupBy(x => x.Name)
                .Select(grp => grp.Aggregate((max, cur) => 
                    (max == null || cur.Rank > max.Rank) ? cur : max))
                .ToListAsync();
        }

        public ValueTask<IEnumerable<Achievement>> ListAsync()
        {
            return new ValueTask<IEnumerable<Achievement>>(set);
        }
    }
}
