using Microsoft.EntityFrameworkCore;
using Miki.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.Bot.Models
{
	public class MikiDbContext : DbContext
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region Achievements

			var achievement = modelBuilder.Entity<Achievement>();

			achievement.HasKey(c => new { c.Id, c.Name });
			achievement.Property(x => x.UnlockedAt).HasDefaultValueSql("now()");

			#endregion Achievements

			#region BackgroundsOwned

			var backgroundsOwned = modelBuilder.Entity<BackgroundsOwned>();

			backgroundsOwned.HasKey(x => new { x.UserId, x.BackgroundId });

			#endregion BackgroundsOwned

			#region Command Usage

			var commandUsage = modelBuilder.Entity<CommandUsage>();

			commandUsage
				.HasKey(c => new { c.UserId, c.Name });

			commandUsage
				.Property(x => x.Amount)
				.HasDefaultValue(1);

			#endregion Command Usage

			#region Connections

			var conn = modelBuilder.Entity<Connection>();
			conn.HasKey(x => x.UserId);

			#endregion Connections

			#region DonatorKey

			var donatorKey = modelBuilder.Entity<DonatorKey>();
			donatorKey.HasKey(x => x.Key);
			donatorKey.Property(x => x.Key).HasDefaultValueSql("uuid_generate_v4()");
			donatorKey.Property("StatusTime").HasDefaultValueSql("interval '31 days'");

			#endregion DonatorKey

			#region Event Message

			var eventMessage = modelBuilder.Entity<EventMessage>();

			eventMessage
				.HasKey(c => new { c.ChannelId, c.EventType });

			#endregion Event Message

			#region Local Experience

			var localExperience = modelBuilder.Entity<LocalExperience>();

			localExperience
				.HasKey(c => new { c.ServerId, c.UserId });

			localExperience
				.Property(x => x.Experience)
				.HasDefaultValue(0);

			#endregion Local Experience

			#region Guild User

			var guildUser = modelBuilder.Entity<GuildUser>();
			guildUser.HasKey(x => x.Id);

			guildUser.Property(x => x.Banned)
				.HasDefaultValue(false);

			guildUser.Property(x => x.VisibleOnLeaderboards)
				.HasDefaultValue(false);

			guildUser.Property(x => x.LastRivalRenewed)
				.HasDefaultValueSql("now() - INTERVAL '1 day'");

			guildUser.Property(x => x.MinimalExperienceToGetRewards)
				.HasDefaultValue(100);

			guildUser.Property(x => x.RivalId)
				.HasDefaultValue(0);

			guildUser.Property(x => x.UserCount)
				.HasDefaultValue(0);

			#endregion Guild User

			#region Level Role

			var role = modelBuilder.Entity<LevelRole>();

			role.HasKey(c => new { c.GuildId, c.RoleId });

			role.Property(x => x.Automatic)
				.IsRequired()
				.HasDefaultValue(false);

			role.Property(x => x.Optable)
				.IsRequired()
				.HasDefaultValue(false);

			role.Property(x => x.RequiredRole)
				.HasDefaultValue(0);

			role.Property(x => x.RequiredLevel)
				.HasDefaultValue(0);

			#endregion Level Role

			#region Marriage

			var Marriage = modelBuilder.Entity<Marriage>();

			Marriage.Property(x => x.MarriageId)
				.ValueGeneratedOnAdd();

			Marriage.HasKey(x => x.MarriageId);

			Marriage.Property(x => x.TimeOfProposal)
				.HasDefaultValueSql("now()");

			#endregion Marriage

			#region Global Pasta

			var globalPasta = modelBuilder.Entity<GlobalPasta>();

			globalPasta
				.HasKey(c => c.Id);

			globalPasta
				.Property(x => x.CreatedAt)
				.HasDefaultValueSql("now()");

			#endregion Global Pasta

			#region ProfileVisuals

			var profileVisuals = modelBuilder.Entity<ProfileVisuals>();

			profileVisuals.Property(x => x.UserId).HasDefaultValue(0);
			profileVisuals.HasKey(x => x.UserId);

			profileVisuals.Property(x => x.BackgroundId).HasDefaultValue(0);
			profileVisuals.Property(x => x.ForegroundColor).HasDefaultValue("#000000");
			profileVisuals.Property(x => x.BackgroundColor).HasDefaultValue("#000000");

			#endregion ProfileVisuals

			#region Setting

			modelBuilder.Entity<Setting>()
				.HasKey(c => new { c.EntityId, c.SettingId });

			#endregion Setting

			#region User

			var user = modelBuilder.Entity<User>();

			user.HasKey(c => c.Id);

			user.Property(x => x.AvatarUrl)
				.HasDefaultValue("default");

			user.Property(x => x.Banned)
				.HasDefaultValue(false);

			user.Property(x => x.Currency)
				.HasDefaultValue(0);

			user.Property(x => x.DateCreated)
				.HasDefaultValueSql("now()");

			user.Property(x => x.HeaderUrl)
				.HasDefaultValue("default");

			user.Property(x => x.LastDailyTime)
				.HasDefaultValueSql("now() - interval '1 day'");

			user.Property(x => x.MarriageSlots)
				.HasDefaultValue(0);

			user.Property(x => x.Reputation)
				.HasDefaultValue(0);

			user.Property(x => x.Title)
				.HasDefaultValue("");

			user.Property(x => x.Total_Commands)
				.HasDefaultValue(0);

			user.Property(x => x.Total_Experience)
				.HasDefaultValue(0);

			user.Property(X => X.DblVotes)
				.HasDefaultValue(0);

			user.HasMany(x => x.CommandsUsed)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.HasPrincipalKey(x => x.Id);

			user.HasMany(x => x.LocalExperience)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.HasPrincipalKey(x => x.Id);

			user.HasMany(x => x.Pastas)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.CreatorId)
				.HasPrincipalKey(x => x.Id);

			#endregion User

			#region IsDonator

			var isDonator = modelBuilder.Entity<IsDonator>();
			isDonator.HasKey(x => x.UserId);
			isDonator.Property(x => x.UserId).ValueGeneratedNever();

			isDonator.Property(x => x.TotalPaidCents).HasDefaultValue(0);
			isDonator.Property(x => x.ValidUntil).HasDefaultValueSql("now()");

			#endregion IsDonator

			#region UserMarriedTo

			var usermarried = modelBuilder.Entity<UserMarriedTo>();

			usermarried.HasKey(x => new { x.AskerId, x.ReceiverId });

			usermarried.HasOne(x => x.Marriage)
				.WithOne(x => x.Participants);

			#endregion UserMarriedTo

			#region Pasta Vote

			modelBuilder.Entity<PastaVote>()
				.HasKey(c => new { c.Id, c.UserId });

			#endregion Pasta Vote

			#region Queries
			modelBuilder.Query<RankObject>().ToView("mview_glob_rank_exp");
			#endregion

			modelBuilder.HasDefaultSchema("dbo");
		}
	}
}
