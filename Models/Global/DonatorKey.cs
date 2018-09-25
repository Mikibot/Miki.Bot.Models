using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Miki.Models
{
    public class DonatorKey
    {
		public Guid Key { get; set; }

		public TimeSpan StatusTime { get; set; }

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
