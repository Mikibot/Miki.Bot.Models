using Microsoft.EntityFrameworkCore;
using Miki.Bot.Models.Exceptions;
using System;
using System.Threading.Tasks;
using Miki.Patterns.Repositories;

namespace Miki.Bot.Models
{
    public class DonatorKey
	{
		public Guid Key { get; set; }

		public TimeSpan StatusTime { get; set; }

        public static async Task<DonatorKey> GetKeyAsync(IAsyncRepository<DonatorKey> context, Guid key)
        {
            DonatorKey entity = await context.GetAsync(key);
            if(entity == null)
            {
                throw new DonatorKeyNullException();
            }

            return entity;
        }

        public static async Task<DonatorKey> GenerateNewAsync(DbContext context, TimeSpan? time = null)
		{
			var key = await context.Set<DonatorKey>()
				.AddAsync(new DonatorKey()
				{
					StatusTime = time ?? new TimeSpan(31, 0, 0, 0),
				});

			return key.Entity;
		}
	}
}