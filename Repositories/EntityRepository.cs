using System.Collections.Generic;
namespace Miki.Bot.Models.Repositories
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Miki.Patterns.Repositories;

    public class EntityRepository<T> : IAsyncRepository<T>
        where T : class
    {
        private readonly DbSet<T> set;

        public EntityRepository(DbContext context)
        {
            this.set = context.Set<T>();
        }

        public ValueTask AddAsync(T entity)
        {
            set.Add(entity);
            return default;
        }

        public ValueTask DeleteAsync(T entity)
        {
            set.Remove(entity);
            return default;
        }

        public ValueTask EditAsync(T entity)
        {
            set.Update(entity);
            return default;
        }

        public ValueTask<T> GetAsync(params object[] id)
        {
            return set.FindAsync(id);
        }

        public ValueTask<IEnumerable<T>> ListAsync()
        {
            return new ValueTask<IEnumerable<T>>(set);
        }
    }
}
