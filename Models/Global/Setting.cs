using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Miki.Bot.Models
{
	public enum DatabaseSettingId
	{
		LevelUps = 0,
        Achievements = 1
	};

	[Table("Settings")]
	public class Setting
	{
		[Key]
		[Column("EntityId", Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long EntityId { get; set; }

		[Key]
		[Column("SettingId", Order = 1)]
		public DatabaseSettingId SettingId { get; set; }

		[Column("Value")]
		public int Value { get; set; }

		public static async Task<int> GetAsync(
            DbContext context, 
            ulong id, 
            DatabaseSettingId settingId)
		=> await GetAsync(context, (long)id, settingId);

		public static async Task<int> GetAsync(
            DbContext context, 
            long id, 
            DatabaseSettingId settingId)
		{
			Setting s = await context.Set<Setting>()
				.FindAsync(id, settingId);
			if (s == null)
			{
				s = (await context.Set<Setting>()
					.AddAsync(new Setting()
					{
						EntityId = id,
						SettingId = settingId,
						Value = 0
					})).Entity;
			}
			return s.Value;
		}

		public static async Task UpdateAsync(
            DbContext context, 
            long id, 
            DatabaseSettingId settingId, 
            int value)
		{
			Setting s = await context.Set<Setting>().FindAsync(id, settingId);
			if (s == null)
			{
				await context.AddAsync(new Setting()
				{
					EntityId = id,
					SettingId = settingId,
					Value = value
				});
			}
			else
			{
				s.Value = value;
			}
		}

		public static async Task UpdateAsync(
            DbContext context, 
            ulong id, 
            DatabaseSettingId settingId, 
            int value)
			=> await UpdateAsync(context, (long)id, settingId, value);
	}
}