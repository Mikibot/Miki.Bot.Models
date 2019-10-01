namespace Miki.Bot.Models.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Miki.Patterns.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class LocalExperienceRepository : IAsyncRepository<LocalExperience>
	{
		private readonly DbSet<LocalExperience> set;

		public LocalExperienceRepository(DbContext context)
		{
			set = context.Set<LocalExperience>();
		}

		public ValueTask AddAsync(LocalExperience entity)
		{
			set.Add(entity);
            return default;
        }

		public ValueTask DeleteAsync(LocalExperience entity)
		{
			set.Remove(entity);
            return default;
        }

		public ValueTask EditAsync(LocalExperience entity)
		{
			set.Update(entity);
            return default;
		}

		public async ValueTask<LocalExperience> GetAsync(params object[] id)
		{
			return await set.FindAsync(id);
		}

        public ValueTask<IEnumerable<LocalExperience>> ListAsync()
        {
            return new ValueTask<IEnumerable<LocalExperience>>(set);
        }
    }
}