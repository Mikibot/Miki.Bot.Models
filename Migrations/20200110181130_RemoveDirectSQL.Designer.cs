﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Miki.Bot.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Miki.Migrations
{
    [DbContext(typeof(MikiDbContext))]
    [Migration("20200110181130_RemoveDirectSQL")]
    partial class RemoveDirectSQL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Miki.Bot.Models.Achievement", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<short>("Rank")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UnlockedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("UserId", "Name", "Rank");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("Miki.Bot.Models.BackgroundsOwned", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("BackgroundId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "BackgroundId");

                    b.ToTable("BackgroundsOwned");
                });

            modelBuilder.Entity("Miki.Bot.Models.BankAccount", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("GuildId")
                        .HasColumnType("bigint");

                    b.Property<long>("Currency")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalDeposited")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "GuildId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("Miki.Bot.Models.CommandUsage", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.HasKey("UserId", "Name");

                    b.ToTable("CommandUsages");
                });

            modelBuilder.Entity("Miki.Bot.Models.Config", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("BunnyCdnKey")
                        .HasColumnName("BunnyCdnKey")
                        .HasColumnType("text");

                    b.Property<string>("CdnAccessKey")
                        .HasColumnName("CdnAccessKey")
                        .HasColumnType("text");

                    b.Property<string>("CdnRegionEndpoint")
                        .HasColumnName("CdnRegionEndpoint")
                        .HasColumnType("text");

                    b.Property<string>("CdnSecretKey")
                        .HasColumnName("CdnSecretKey")
                        .HasColumnType("text");

                    b.Property<string>("DanbooruCredentials")
                        .HasColumnName("DanbooruCredentials")
                        .HasColumnType("text");

                    b.Property<string>("DatadogHost")
                        .HasColumnName("DatadogHost")
                        .HasColumnType("text");

                    b.Property<string>("ImageApiUrl")
                        .HasColumnName("ImageApiUrl")
                        .HasColumnType("text");

                    b.Property<string>("MikiApiBaseUrl")
                        .HasColumnName("MikiApiBaseUrl")
                        .HasColumnType("text");

                    b.Property<string>("MikiApiKey")
                        .HasColumnName("MikiApiKey")
                        .HasColumnType("text");

                    b.Property<string>("RabbitUrl")
                        .HasColumnName("RabbitUrl")
                        .HasColumnType("text");

                    b.Property<string>("RedisConnectionString")
                        .HasColumnName("RedisConnectionString")
                        .HasColumnType("text");

                    b.Property<string>("SharpRavenKey")
                        .HasColumnName("SharpRavenKey")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnName("Token")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Configuration");
                });

            modelBuilder.Entity("Miki.Bot.Models.Connection", b =>
                {
                    b.Property<decimal>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<long>("DiscordUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("PatreonUserId")
                        .HasColumnType("text");

                    b.Property<long?>("UserId1")
                        .HasColumnType("bigint");

                    b.HasKey("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("Miki.Bot.Models.CustomCommand", b =>
                {
                    b.Property<long>("GuildId")
                        .HasColumnType("bigint");

                    b.Property<string>("CommandName")
                        .HasColumnType("text");

                    b.Property<string>("CommandBody")
                        .HasColumnType("text");

                    b.HasKey("GuildId", "CommandName");

                    b.ToTable("CustomCommands");
                });

            modelBuilder.Entity("Miki.Bot.Models.DonatorKey", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<TimeSpan>("StatusTime")
                        .HasColumnType("interval");

                    b.HasKey("Key");

                    b.ToTable("DonatorKey");
                });

            modelBuilder.Entity("Miki.Bot.Models.EventMessage", b =>
                {
                    b.Property<long>("ChannelId")
                        .HasColumnName("ChannelId")
                        .HasColumnType("bigint");

                    b.Property<short>("EventType")
                        .HasColumnName("EventType")
                        .HasColumnType("smallint");

                    b.Property<string>("Message")
                        .HasColumnName("Message")
                        .HasColumnType("text");

                    b.HasKey("ChannelId", "EventType");

                    b.ToTable("EventMessages");
                });

            modelBuilder.Entity("Miki.Bot.Models.GlobalPasta", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int>("TimesUsed")
                        .HasColumnType("integer");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pastas");
                });

            modelBuilder.Entity("Miki.Bot.Models.GuildUser", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("EntityId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Banned")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("banned")
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<long>("Currency")
                        .HasColumnType("bigint");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<int>("GuildHouseLevel")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastRivalRenewed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("MinimalExperienceToGetRewards")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(100);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("RivalId")
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<int>("UserCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<bool>("VisibleOnLeaderboards")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("GuildUsers");
                });

            modelBuilder.Entity("Miki.Bot.Models.IsDonator", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("CurrentBalance")
                        .HasColumnType("integer");

                    b.Property<int>("KeysRedeemed")
                        .HasColumnType("integer");

                    b.Property<int>("TotalPaidCents")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("UserId");

                    b.ToTable("IsDonator");
                });

            modelBuilder.Entity("Miki.Bot.Models.Item", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<long?>("ResourceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id", "UserId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("UserId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Miki.Bot.Models.ItemResource", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("StackSize")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ItemResource");
                });

            modelBuilder.Entity("Miki.Bot.Models.LevelRole", b =>
                {
                    b.Property<long>("GuildId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Automatic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("Optable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("RequiredLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<long>("RequiredRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.HasKey("GuildId", "RoleId");

                    b.ToTable("LevelRoles");
                });

            modelBuilder.Entity("Miki.Bot.Models.LocalExperience", b =>
                {
                    b.Property<long>("ServerId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("Experience")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("ServerId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("LocalExperience");
                });

            modelBuilder.Entity("Miki.Bot.Models.Marriage", b =>
                {
                    b.Property<long>("MarriageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsProposing")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TimeOfMarriage")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimeOfProposal")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("MarriageId");

                    b.ToTable("Marriages");
                });

            modelBuilder.Entity("Miki.Bot.Models.Models.Authorization.APIApplication", b =>
                {
                    b.Property<long>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid>("ApplicationSecret")
                        .HasColumnType("uuid");

                    b.Property<long?>("DataApplicationId")
                        .HasColumnType("bigint");

                    b.Property<long>("LastResetEpoch")
                        .HasColumnType("bigint");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<long>("Permissions")
                        .HasColumnType("bigint");

                    b.Property<double>("RatelimitMultiplier")
                        .HasColumnType("double precision");

                    b.HasKey("ApplicationId");

                    b.HasIndex("DataApplicationId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Miki.Bot.Models.Models.Authorization.APIApplicationData", b =>
                {
                    b.Property<long>("ApplicationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ApplicationId");

                    b.ToTable("APIApplicationData");
                });

            modelBuilder.Entity("Miki.Bot.Models.Models.User.IsBanned", b =>
                {
                    b.Property<long>("BanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimeOfBan")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("BanId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("IsBanned");
                });

            modelBuilder.Entity("Miki.Bot.Models.ModuleState", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("GuildId")
                        .HasColumnType("bigint");

                    b.Property<bool>("State")
                        .HasColumnType("boolean");

                    b.HasKey("Name", "GuildId");

                    b.ToTable("ModuleStates");
                });

            modelBuilder.Entity("Miki.Bot.Models.PastaVote", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnName("UserId")
                        .HasColumnType("bigint");

                    b.Property<bool>("PositiveVote")
                        .HasColumnName("PositiveVote")
                        .HasColumnType("boolean");

                    b.HasKey("Id", "UserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Miki.Bot.Models.ProfileVisuals", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<string>("BackgroundColor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("#000000");

                    b.Property<int>("BackgroundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("ForegroundColor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("#000000");

                    b.HasKey("UserId");

                    b.ToTable("ProfileVisuals");
                });

            modelBuilder.Entity("Miki.Bot.Models.Setting", b =>
                {
                    b.Property<long>("EntityId")
                        .HasColumnName("EntityId")
                        .HasColumnType("bigint");

                    b.Property<int>("SettingId")
                        .HasColumnName("SettingId")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnName("Value")
                        .HasColumnType("integer");

                    b.HasKey("EntityId", "SettingId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Miki.Bot.Models.Timer", b =>
                {
                    b.Property<long>("GuildId")
                        .HasColumnName("GuildId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnName("UserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Value")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("GuildId", "UserId");

                    b.ToTable("Timers");
                });

            modelBuilder.Entity("Miki.Bot.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AvatarUrl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("default");

                    b.Property<bool>("Banned")
                        .HasColumnType("boolean");

                    b.Property<int>("Currency")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DblVotes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("HeaderUrl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("default");

                    b.Property<DateTime>("LastDailyTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("MarriageSlots")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Reputation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("Title")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("");

                    b.Property<int>("Total_Commands")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Total_Experience")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Miki.Bot.Models.UserMarriedTo", b =>
                {
                    b.Property<long>("AskerId")
                        .HasColumnType("bigint");

                    b.Property<long>("ReceiverId")
                        .HasColumnType("bigint");

                    b.Property<long>("MarriageId")
                        .HasColumnType("bigint");

                    b.HasKey("AskerId", "ReceiverId");

                    b.HasIndex("MarriageId")
                        .IsUnique();

                    b.ToTable("UsersMarriedTo");
                });

            modelBuilder.Entity("Miki.Framework.Commands.Localization.Models.ChannelLanguage", b =>
                {
                    b.Property<long>("EntityId")
                        .HasColumnName("EntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Language")
                        .HasColumnName("Language")
                        .HasColumnType("text");

                    b.HasKey("EntityId");

                    b.ToTable("ChannelLanguage");
                });

            modelBuilder.Entity("Miki.Framework.Commands.Permissions.Models.Permission", b =>
                {
                    b.Property<long>("EntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("CommandName")
                        .HasColumnType("text");

                    b.Property<long>("GuildId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("EntityId", "CommandName", "GuildId");

                    b.HasIndex("GuildId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Miki.Framework.Commands.Prefixes.Models.Prefix", b =>
                {
                    b.Property<long>("GuildId")
                        .HasColumnType("bigint");

                    b.Property<string>("DefaultValue")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("GuildId", "DefaultValue");

                    b.ToTable("Identifiers");
                });

            modelBuilder.Entity("Miki.Framework.Commands.Scopes.Models.Scope", b =>
                {
                    b.Property<string>("ScopeId")
                        .HasColumnName("ScopeId")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnName("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("ScopeId", "UserId");

                    b.ToTable("Scopes");
                });

            modelBuilder.Entity("Miki.Models.User.UserLog", b =>
                {
                    b.Property<long>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Action")
                        .HasColumnType("integer");

                    b.Property<string>("Context")
                        .HasColumnType("text");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LogId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogs");
                });

            modelBuilder.Entity("Miki.Bot.Models.Achievement", b =>
                {
                    b.HasOne("Miki.Bot.Models.User", null)
                        .WithMany("Achievements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Miki.Bot.Models.CommandUsage", b =>
                {
                    b.HasOne("Miki.Bot.Models.User", "User")
                        .WithMany("CommandsUsed")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Miki.Bot.Models.Connection", b =>
                {
                    b.HasOne("Miki.Bot.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Miki.Bot.Models.GlobalPasta", b =>
                {
                    b.HasOne("Miki.Bot.Models.User", null)
                        .WithMany("Pastas")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Miki.Bot.Models.Item", b =>
                {
                    b.HasOne("Miki.Bot.Models.ItemResource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId");

                    b.HasOne("Miki.Bot.Models.User", null)
                        .WithMany("Inventory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Miki.Bot.Models.LocalExperience", b =>
                {
                    b.HasOne("Miki.Bot.Models.User", "User")
                        .WithMany("LocalExperience")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Miki.Bot.Models.Models.Authorization.APIApplication", b =>
                {
                    b.HasOne("Miki.Bot.Models.Models.Authorization.APIApplicationData", "Data")
                        .WithMany()
                        .HasForeignKey("DataApplicationId");
                });

            modelBuilder.Entity("Miki.Bot.Models.UserMarriedTo", b =>
                {
                    b.HasOne("Miki.Bot.Models.Marriage", "Marriage")
                        .WithOne("Participants")
                        .HasForeignKey("Miki.Bot.Models.UserMarriedTo", "MarriageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
