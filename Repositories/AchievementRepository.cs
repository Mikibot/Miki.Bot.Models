using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Miki.Bot.Models.Repositories
{
    public class AchievementRepository : IAsyncRepository<Achievement>
    {


        public Task<Achievement> GetAsync(params object[] id)
        {

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
