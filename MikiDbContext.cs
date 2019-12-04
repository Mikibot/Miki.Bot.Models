namespace Miki.Bot.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Miki.Bot.Models.Models.Authorization;
    using Miki.Bot.Models.Models.User;
    using Miki.Bot.Models.Queries;
    using Miki.Framework.Commands.Localization.Models;
    using Miki.Framework.Commands.Permissions.Models;
    using Miki.Framework.Commands.Prefixes.Models;
    using Miki.Framework.Commands.Scopes.Models;
    using Miki.Models.User;

    public class MikiDbContext : DbContext
	{
        public DbSet<APIApplication> Applications { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<BackgroundsOwned> BackgroundsOwned { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<ChannelLanguage> ChannelLanguages { get; set; }
        public DbSet<CommandUsage> CommandUsages { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<CustomCommand> CustomCommands { get; set; }
        public DbSet<Config> Configurations { get; set; }
        public DbSet<DailyStreak> DailyStreaks { get; set; } 
        public DbSet<Prefix> Identifiers { get; set; }
        public DbSet<IsDonator> IsDonator { get; set; }
        public DbSet<DonatorKey> DonatorKey { get; set; }
        public DbSet<EventMessage> EventMessages { get; set; }
        public DbSet<LocalExperience> LocalExperience { get; set; }
        public DbSet<GuildUser> GuildUsers { get; set; }
        public DbSet<LevelRole> LevelRoles { get; set; }
        public DbSet<Marriage> Marriages { get; set; }
        public DbSet<ModuleState> ModuleStates { get; set; }
        public DbSet<GlobalPasta> Pastas { get; set; }
        public DbSet<ProfileVisuals> ProfileVisuals { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Scope> Scopes { get; set; }    
        public DbSet<Timer> Timers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<IsBanned> IsBanned { get; set; }
        public DbSet<UserMarriedTo> UsersMarriedTo { get; set; }
        public DbSet<PastaVote> Votes { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        private MikiDbContext()
        { }

        public MikiDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region Achievements
			var achievement = modelBuilder.Entity<Achievement>();

            achievement
                .HasKey(c => new { c.UserId, c.Name, c.Rank });
            
            #endregion Achievements

            #region APIToken
            modelBuilder.Entity<APIApplication>(model =>
            {
                model.HasKey(x => x.ApplicationId);
                model.HasOne(x => x.Data);
            });
            #endregion

            #region APIApplicationData
            modelBuilder.Entity<APIApplicationData>(model =>
            {
                model.HasKey(x => x.ApplicationId);

                model.Property(x => x.ApplicationId)
                    .ValueGeneratedNever();
            });
            #endregion

            #region BankAccounts
            var bankAccount = modelBuilder.Entity<BankAccount>();
            bankAccount.HasKey(x => new { x.UserId, x.GuildId });
            #endregion

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

            #region Custom Commands
            var commands = modelBuilder.Entity<CustomCommand>();
            commands.HasKey(x => new { x.GuildId, x.CommandName });
            #endregion

            #region Daily Streaks
            var dailyStreak = modelBuilder.Entity<DailyStreak>();

            dailyStreak
                .HasKey(c => new { c.UserId });

            #endregion Achievements

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

            #region Prefix
            var identifier = modelBuilder.Entity<Prefix>();
            identifier.HasKey(x => new { x.GuildId, x.DefaultValue });
            #endregion

            #region ModuleState
            var moduleState = modelBuilder.Entity<ModuleState>();
            moduleState.HasKey(x => new { x.Name, x.GuildId });
            #endregion

            #region ChannelLanguage
            var channelLanguage = modelBuilder.Entity<ChannelLanguage>();
            channelLanguage.HasKey(x => new { x.EntityId });
            #endregion

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
				.HasDefaultValue(DateTime.MinValue);

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
            #endregion Marriage

            #region Global Pasta
            var globalPasta = modelBuilder.Entity<GlobalPasta>();
			globalPasta.HasKey(c => c.Id);
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

            #region Scopes

            var scopeModel = modelBuilder.Entity<Scope>();
            scopeModel.HasKey(x => new
            {
                x.ScopeId,
                x.UserId
            });

            #endregion

            #region Permissions
            var permissionsModel = modelBuilder.Entity<Permission>();
            permissionsModel.HasKey(x => new {x.EntityId, x.CommandName, x.GuildId});
            permissionsModel.HasIndex(x => x.GuildId);
            #endregion

            #region User

            var user = modelBuilder.Entity<User>();

			user.HasKey(c => c.Id);

			user.Property(x => x.AvatarUrl)
				.HasDefaultValue("default");

			user.Property(x => x.Currency)
				.HasDefaultValue(0);

            user.Property(x => x.HeaderUrl)
				.HasDefaultValue("default");

			user.Property(x => x.LastDailyTime)
				.HasDefaultValue(DateTime.MinValue);

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

            #region UserLog

            var userLog = modelBuilder.Entity<UserLog>();
            userLog.HasKey(x => x.LogId);
            userLog.HasIndex(x => x.UserId);

            #endregion

            #region IsBanned
            var isBanned = modelBuilder.Entity<IsBanned>();
            isBanned.HasKey(x => new { x.BanId, x.UserId });
            isBanned.HasIndex(x => new { x.UserId });
            isBanned.Property(x => x.BanId).ValueGeneratedOnAdd();
            #endregion

            #region IsDonator

            var isDonator = modelBuilder.Entity<IsDonator>();
			isDonator.HasKey(x => x.UserId);
			isDonator.Property(x => x.UserId).ValueGeneratedNever();

			isDonator.Property(x => x.TotalPaidCents).HasDefaultValue(0);

            #endregion IsDonator

            #region Item
            var item = modelBuilder.Entity<Item>();
            item.HasKey(x => new { x.Id, x.UserId });
            item.HasOne(x => x.Resource);
            #endregion

            #region ItemResource 
            var itemResource = modelBuilder.Entity<ItemResource>();
            itemResource.HasKey(x => x.Id);
            #endregion

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

            #region Timer
            var timers = modelBuilder.Entity<Timer>();
            timers.HasKey(x => new { x.GuildId, x.UserId });
            #endregion

            #region Queries
            modelBuilder
                .Entity<RankObject>()
                .HasNoKey()
                .ToView("mview_glob_rank_exp");
            #endregion

            modelBuilder.HasDefaultSchema("dbo");
		}
	}
}
