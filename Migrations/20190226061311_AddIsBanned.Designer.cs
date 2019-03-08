﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Miki.Bot.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Miki.Core.Migrations
{
    [DbContext(typeof(MikiDbContext))]
    [Migration("20190226061311_AddIsBanned")]
    partial class AddIsBanned
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Miki.Bot.Models.Achievement", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("Name");

                    b.Property<short>("Rank");

                    b.Property<DateTime>("UnlockedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.HasKey("UserId", "Name");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("Miki.Bot.Models.BackgroundsOwned", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<int>("BackgroundId");

                    b.HasKey("UserId", "BackgroundId");

                    b.ToTable("BackgroundsOwned");
                });

            modelBuilder.Entity("Miki.Bot.Models.BankAccount", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("GuildId");

                    b.Property<long>("Currency");

                    b.Property<long>("TotalDeposited");

                    b.HasKey("UserId", "GuildId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("Miki.Bot.Models.ChannelLanguage", b =>
                {
                    b.Property<long>("EntityId")
                        .HasColumnName("EntityId");

                    b.Property<string>("Language")
                        .HasColumnName("Language");

                    b.HasKey("EntityId");

                    b.ToTable("ChannelLanguage");
                });

            modelBuilder.Entity("Miki.Bot.Models.CommandState", b =>
                {
                    b.Property<string>("Name");

                    b.Property<long>("ChannelId");

                    b.Property<long>("GuildId");

                    b.Property<bool>("State");

                    b.HasKey("Name", "ChannelId");

                    b.ToTable("CommandStates");
                });

            modelBuilder.Entity("Miki.Bot.Models.CommandUsage", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("Name");

                    b.Property<int>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.HasKey("UserId", "Name");

                    b.ToTable("CommandUsages");
                });

            modelBuilder.Entity("Miki.Bot.Models.Connection", b =>
                {
                    b.Property<decimal>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<long>("DiscordUserId");

                    b.Property<string>("PatreonUserId");

                    b.Property<long?>("UserId1");

                    b.HasKey("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("Miki.Bot.Models.CustomCommand", b =>
                {
                    b.Property<long>("GuildId");

                    b.Property<string>("CommandName");

                    b.Property<string>("CommandBody");

                    b.HasKey("GuildId", "CommandName");

                    b.ToTable("CustomCommands");
                });

            modelBuilder.Entity("Miki.Bot.Models.DonatorKey", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<TimeSpan>("StatusTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("interval '31 days'");

                    b.HasKey("Key");

                    b.ToTable("DonatorKey");
                });

            modelBuilder.Entity("Miki.Bot.Models.EventMessage", b =>
                {
                    b.Property<long>("ChannelId")
                        .HasColumnName("ChannelId");

                    b.Property<short>("EventType")
                        .HasColumnName("EventType");

                    b.Property<string>("Message")
                        .HasColumnName("Message");

                    b.HasKey("ChannelId", "EventType");

                    b.ToTable("EventMessages");
                });

            modelBuilder.Entity("Miki.Bot.Models.GlobalPasta", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 2, 26, 6, 13, 11, 313, DateTimeKind.Utc).AddTicks(2576));

                    b.Property<long>("CreatorId");

                    b.Property<int>("Score");

                    b.Property<string>("Text");

                    b.Property<int>("TimesUsed");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Pastas");
                });

            modelBuilder.Entity("Miki.Bot.Models.GuildUser", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("EntityId");

                    b.Property<bool>("Banned")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("banned")
                        .HasDefaultValue(false);

                    b.Property<long>("Currency");

                    b.Property<int>("Experience");

                    b.Property<int>("GuildHouseLevel");

                    b.Property<DateTime>("LastRivalRenewed")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now() - INTERVAL '1 day'");

                    b.Property<int>("MinimalExperienceToGetRewards")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(100);

                    b.Property<string>("Name");

                    b.Property<long>("RivalId")
                        .HasDefaultValue(0L);

                    b.Property<int>("UserCount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<bool>("VisibleOnLeaderboards")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("GuildUsers");
                });

            modelBuilder.Entity("Miki.Bot.Models.Identifier", b =>
                {
                    b.Property<long>("GuildId");

                    b.Property<string>("DefaultValue");

                    b.Property<string>("Value");

                    b.HasKey("GuildId", "DefaultValue");

                    b.ToTable("Identifiers");
                });

            modelBuilder.Entity("Miki.Bot.Models.IsDonator", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<int>("CurrentBalance");

                    b.Property<int>("KeysRedeemed");

                    b.Property<int>("TotalPaidCents")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<DateTime>("ValidUntil")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 2, 26, 6, 13, 11, 324, DateTimeKind.Utc).AddTicks(4549));

                    b.HasKey("UserId");

                    b.ToTable("IsDonator");
                });

            modelBuilder.Entity("Miki.Bot.Models.LevelRole", b =>
                {
                    b.Property<long>("GuildId");

                    b.Property<long>("RoleId");

                    b.Property<bool>("Automatic")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("Optable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int>("Price");

                    b.Property<int>("RequiredLevel")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<long>("RequiredRole")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0L);

                    b.HasKey("GuildId", "RoleId");

                    b.ToTable("LevelRoles");
                });

            modelBuilder.Entity("Miki.Bot.Models.LocalExperience", b =>
                {
                    b.Property<long>("ServerId");

                    b.Property<long>("UserId");

                    b.Property<int>("Experience")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.HasKey("ServerId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("LocalExperience");
                });

            modelBuilder.Entity("Miki.Bot.Models.Marriage", b =>
                {
                    b.Property<long>("MarriageId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsProposing");

                    b.Property<DateTime>("TimeOfMarriage");

                    b.Property<DateTime>("TimeOfProposal")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 2, 26, 6, 13, 11, 312, DateTimeKind.Utc).AddTicks(9165));

                    b.HasKey("MarriageId");

                    b.ToTable("Marriages");
                });

            modelBuilder.Entity("Miki.Bot.Models.Models.Authorization.APIApplication", b =>
                {
                    b.Property<long>("ApplicationId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApplicationSecret")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new Guid("72d314d0-e555-4952-b6fe-c31829562ae1"));

                    b.Property<long?>("DataApplicationId");

                    b.Property<long>("LastResetEpoch");

                    b.Property<long>("OwnerId");

                    b.Property<long>("Permissions");

                    b.Property<double>("RatelimitMultiplier");

                    b.HasKey("ApplicationId");

                    b.HasIndex("DataApplicationId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Miki.Bot.Models.Models.Authorization.APIApplicationData", b =>
                {
                    b.Property<long>("ApplicationId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ApplicationId");

                    b.ToTable("APIApplicationData");
                });

            modelBuilder.Entity("Miki.Bot.Models.Models.User.IsBanned", b =>
                {
                    b.Property<long>("BanId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("UserId");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<DateTime>("TimeOfBan");

                    b.HasKey("BanId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("IsBanned");
                });

            modelBuilder.Entity("Miki.Bot.Models.ModuleState", b =>
                {
                    b.Property<string>("Name");

                    b.Property<long>("GuildId");

                    b.Property<bool>("State");

                    b.HasKey("Name", "GuildId");

                    b.ToTable("ModuleStates");
                });

            modelBuilder.Entity("Miki.Bot.Models.PastaVote", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("Id");

                    b.Property<long>("UserId")
                        .HasColumnName("UserId");

                    b.Property<bool>("PositiveVote")
                        .HasColumnName("PositiveVote");

                    b.HasKey("Id", "UserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Miki.Bot.Models.ProfileVisuals", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0L);

                    b.Property<string>("BackgroundColor")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("#000000");

                    b.Property<int>("BackgroundId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("ForegroundColor")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("#000000");

                    b.HasKey("UserId");

                    b.ToTable("ProfileVisuals");
                });

            modelBuilder.Entity("Miki.Bot.Models.Setting", b =>
                {
                    b.Property<long>("EntityId")
                        .HasColumnName("EntityId");

                    b.Property<int>("SettingId")
                        .HasColumnName("SettingId");

                    b.Property<int>("Value")
                        .HasColumnName("Value");

                    b.HasKey("EntityId", "SettingId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Miki.Bot.Models.Timer", b =>
                {
                    b.Property<long>("GuildId")
                        .HasColumnName("GuildId");

                    b.Property<long>("UserId")
                        .HasColumnName("UserId");

                    b.Property<DateTime>("Value");

                    b.HasKey("GuildId", "UserId");

                    b.ToTable("Timers");
                });

            modelBuilder.Entity("Miki.Bot.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AvatarUrl")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("default");

                    b.Property<bool>("Banned")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int>("Currency")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 2, 26, 6, 13, 11, 314, DateTimeKind.Utc).AddTicks(8393));

                    b.Property<int>("DblVotes")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("HeaderUrl")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("default");

                    b.Property<DateTime>("LastDailyTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("MarriageSlots")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("Name");

                    b.Property<int>("Reputation")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("Title")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("");

                    b.Property<int>("Total_Commands")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("Total_Experience")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Miki.Bot.Models.UserMarriedTo", b =>
                {
                    b.Property<long>("AskerId");

                    b.Property<long>("ReceiverId");

                    b.Property<long>("MarriageId");

                    b.HasKey("AskerId", "ReceiverId");

                    b.HasIndex("MarriageId")
                        .IsUnique();

                    b.ToTable("UsersMarriedTo");
                });

            modelBuilder.Entity("Miki.Bot.Models.Achievement", b =>
                {
                    b.HasOne("Miki.Bot.Models.User")
                        .WithMany("Achievements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Miki.Bot.Models.CommandUsage", b =>
                {
                    b.HasOne("Miki.Bot.Models.User", "User")
                        .WithMany("CommandsUsed")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Miki.Bot.Models.Connection", b =>
                {
                    b.HasOne("Miki.Bot.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Miki.Bot.Models.GlobalPasta", b =>
                {
                    b.HasOne("Miki.Bot.Models.User", "User")
                        .WithMany("Pastas")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Miki.Bot.Models.LocalExperience", b =>
                {
                    b.HasOne("Miki.Bot.Models.User", "User")
                        .WithMany("LocalExperience")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
