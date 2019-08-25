using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Miki.Bot.Models.Repositories
{
    public class AchievementRepository : IAsyncRepository<Achievement>
    {
        DbSet<Achievement> set;

        public AchievementRepository(DbContext ctx)
        {
            set = ctx.Set<Achievement>();
        }

        public Task<Achievement> GetAsync(long userId, string name)
        {
            return set.Where(x => x.Name == name
                           && x.UserId == userId)
                .OrderByDescending(x => x.Rank)
                .FirstOrDefaultAsync();
        }
        public Task<Achievement> GetAsync(params object[] id)
        {
            if (id.Length != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            return GetAsync((long)id[0], (string)id[1]);
        }

        public Task AddAsync(Achievement entity)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Achievement entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Achievement entity)
        {
            throw new NotImplementedException();
        }
    }
}
