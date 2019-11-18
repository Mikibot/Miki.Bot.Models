using Microsoft.EntityFrameworkCore;
using Miki.Patterns.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Bot.Models.Repositories
{
	public class MarriageRepository : IAsyncRepository<Marriage>
	{
		private readonly DbContext dbContext;
		private readonly DbSet<Marriage> marriageSet;
		private readonly DbSet<UserMarriedTo> userMarriedSet;

		public MarriageRepository(DbContext context)
		{
			dbContext = context;
			marriageSet = context.Set<Marriage>();
			userMarriedSet = context.Set<UserMarriedTo>();
		}

		public async Task DeclineAllProposalsAsync(long me)
		{
			List<UserMarriedTo> proposals = await InternalGetProposalsReceivedAsync(me);

			proposals.AddRange(await InternalGetProposalsSentAsync(me));

			marriageSet.RemoveRange(proposals.Select(x => x.Marriage).ToList());
			userMarriedSet.RemoveRange(proposals);

			await dbContext.SaveChangesAsync();
		}

		public async Task DivorceAllMarriagesAsync(long me)
		{
			List<UserMarriedTo> marriages = await InternalGetMarriagesAsync(me);
			marriageSet.RemoveRange(marriages.Select(x => x.Marriage));
			await dbContext.SaveChangesAsync();
		}

		public async Task<bool> ExistsAsync(ulong id1, ulong id2)
			=> await ExistsAsync((long)id1, (long)id2);

		public async Task<bool> ExistsAsync(long id1, long id2)
			=> await GetEntryAsync(id1, id2) != null;

		public async Task<bool> ExistsAsMarriageAsync(long id1, long id2)
			=> await GetMarriageAsync(id1, id2) != null;

		public async Task<List<UserMarriedTo>> GetProposalsSent(long asker)
			=> await InternalGetProposalsSentAsync(asker);

		public async Task<List<UserMarriedTo>> GetProposalsReceived(long userid)
			=> await InternalGetProposalsReceivedAsync(userid);

		public async Task<UserMarriedTo> GetMarriageAsync(ulong receiver, ulong asker)
			=> await GetMarriageAsync((long)receiver, (long)asker);

		public async Task<UserMarriedTo> GetMarriageAsync(long receiver, long asker)
		{
            UserMarriedTo m = await InternalGetMarriageAsync(receiver, asker);
            if (m == null)
            {
                m = await InternalGetMarriageAsync(asker, receiver);
            }
			return m;
		}

		public async Task<List<UserMarriedTo>> GetMarriagesAsync(long userid)
			=> await InternalGetMarriagesAsync(userid);

		public async Task<UserMarriedTo> GetEntryAsync(ulong receiver, ulong asker)
			=> await GetEntryAsync((long)receiver, (long)asker);

		public async Task<UserMarriedTo> GetEntryAsync(long receiver, long asker)
		{
             UserMarriedTo m = await userMarriedSet
				.Include(x => x.Marriage)
				.FirstOrDefaultAsync(x => (x.AskerId == asker && x.ReceiverId == receiver)
					|| (x.AskerId == receiver && x.ReceiverId == asker));
			return m;
		}

		public async Task ProposeAsync(long asker, long receiver)
		{
			Marriage m = dbContext.Set<Marriage>().Add(new Marriage()
			{
				IsProposing = true,
				TimeOfProposal = DateTime.Now,
				TimeOfMarriage = DateTime.Now,
			}).Entity;

			userMarriedSet.Add(new UserMarriedTo()
			{
				MarriageId = m.MarriageId,
				ReceiverId = receiver,
				AskerId = asker
			});

			await dbContext.SaveChangesAsync();
		}

		/// <summary>
		/// gets specific proposal
		/// </summary>
		/// <param name="askerid"></param>
		/// <param name="userid"></param>
		/// <returns></returns>
		private async Task<UserMarriedTo> InternalGetProposalAsync(
            long askerid, 
            long userid)
		{
			return await userMarriedSet
				.Include(x => x.Marriage)
				.FirstOrDefaultAsync(x => (x.AskerId == askerid || x.ReceiverId == userid) 
                                          && x.Marriage.IsProposing);
		}

		/// <summary>
		/// gets the proposals sent to userid
		/// </summary>
		/// <param name="asker"></param>
		/// <returns></returns>
		private async Task<List<UserMarriedTo>> InternalGetProposalsSentAsync(long asker)
		{
			var allInstances = await userMarriedSet
				.Include(x => x.Marriage)
				.Where(x => x.AskerId == asker && x.Marriage.IsProposing)
				.ToListAsync();
			return allInstances;
		}

		/// <summary>
		/// Gets the proposals received by userid
		/// </summary>
		/// <param name="userid"></param>
		/// <returns></returns>
		private async Task<List<UserMarriedTo>> InternalGetProposalsReceivedAsync(long userid)
		{
			var allInstances = await userMarriedSet
				.Include(x => x.Marriage)
				.Where(x => x.ReceiverId == userid && x.Marriage.IsProposing)
				.ToListAsync();
			return allInstances;
		}

		/// <summary>
		/// Gets marriage instance of receiver and asker
		/// </summary>
		/// <param name="receiver"></param>
		/// <param name="asker"></param>
		/// <returns></returns>
		private async Task<UserMarriedTo> InternalGetMarriageAsync(long receiver, long asker)
		{
			return await userMarriedSet
				.Include(x => x.Marriage)
				.FirstOrDefaultAsync(x => x.ReceiverId == receiver && x.AskerId == asker && !x.Marriage.IsProposing);
		}

		/// <summary>
		/// Gets all marriages the user id is married to
		/// </summary>
		/// <param name="userid"></param>
		/// <returns></returns>
		private async Task<List<UserMarriedTo>> InternalGetMarriagesAsync(long userid)
		{
			var allInstances = await userMarriedSet
				.Include(x => x.Marriage)
				.Where(x => (x.ReceiverId == userid || x.AskerId == userid) && !x.Marriage.IsProposing)
				.ToListAsync();
			return allInstances;
		}

        public ValueTask<Marriage> GetAsync(params object[] id)
		{
			return new ValueTask<Marriage>(
                marriageSet.Include(x => x.Participants)
				.SingleOrDefaultAsync(x => x.MarriageId == (long)id[0]));
		}

        public ValueTask<IEnumerable<Marriage>> ListAsync()
        {
            return new ValueTask<IEnumerable<Marriage>>(marriageSet);
        }

        public ValueTask AddAsync(Marriage entity)
        {
            throw new NotImplementedException();
        }

        public ValueTask EditAsync(Marriage entity)
        {
            throw new NotImplementedException();
        }

        public ValueTask DeleteAsync(Marriage entity)
        {
            throw new NotImplementedException();
        }
    }
}