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
    [Migration("20181224041123_NpgSQLUpgrade")]
    partial class NpgSQLUpgrade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Miki.Framework.Models.ChannelLanguage", b =>
                {
                    b.Property<long>("EntityId")
                        .HasColumnName("EntityId");

                    b.Property<string>("Language")
                        .HasColumnName("Language");

                    b.HasKey("EntityId");

                    b.ToTable("ChannelLanguage");
                });

            modelBuilder.Entity("Miki.Framework.Models.CommandState", b =>
                {
                    b.Property<string>("Name");

                    b.Property<long>("ChannelId");

                    b.Property<long>("GuildId");

                    b.Property<bool>("State");

                    b.HasKey("Name", "ChannelId");

                    b.ToTable("CommandStates");
                });

            modelBuilder.Entity("Miki.Framework.Models.Prefix", b =>
                {
                    b.Property<long>("GuildId");

                    b.Property<string>("DefaultValue");

                    b.Property<string>("Value");

                    b.HasKey("GuildId", "DefaultValue");

                    b.ToTable("Identifiers");
                });

            modelBuilder.Entity("Miki.Framework.Models.ModuleState", b =>
                {
                    b.Property<string>("Name");

                    b.Property<long>("GuildId");

                    b.Property<bool>("State");

                    b.HasKey("Name", "GuildId");

                    b.ToTable("ModuleStates");
                });

            modelBuilder.Entity("Miki.Models.Achievement", b =>
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

            modelBuilder.Entity("Miki.Models.BackgroundsOwned", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<int>("BackgroundId");

                    b.HasKey("UserId", "BackgroundId");

                    b.ToTable("BackgroundsOwned");
                });

            modelBuilder.Entity("Miki.Models.CommandUsage", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("Name");

                    b.Property<int>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.HasKey("UserId", "Name");

                    b.ToTable("CommandUsages");
                });

            modelBuilder.Entity("Miki.Models.Connection", b =>
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

            modelBuilder.Entity("Miki.Models.DonatorKey", b =>
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

            modelBuilder.Entity("Miki.Models.EventMessage", b =>
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

            modelBuilder.Entity("Miki.Models.GlobalPasta", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<long>("CreatorId");

                    b.Property<int>("Score");

                    b.Property<string>("Text");

                    b.Property<int>("TimesUsed");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Pastas");
                });

            modelBuilder.Entity("Miki.Models.GuildUser", b =>
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

            modelBuilder.Entity("Miki.Models.IsDonator", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<int>("CurrentBalance");

                    b.Property<int>("KeysRedeemed");

                    b.Property<int>("TotalPaidCents")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<DateTime>("ValidUntil")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.HasKey("UserId");

                    b.ToTable("IsDonator");
                });

            modelBuilder.Entity("Miki.Models.LevelRole", b =>
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

            modelBuilder.Entity("Miki.Models.LocalExperience", b =>
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

            modelBuilder.Entity("Miki.Models.Marriage", b =>
                {
                    b.Property<long>("MarriageId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsProposing");

                    b.Property<DateTime>("TimeOfMarriage");

                    b.Property<DateTime>("TimeOfProposal")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.HasKey("MarriageId");

                    b.ToTable("Marriages");
                });

            modelBuilder.Entity("Miki.Models.Objects.Guild.BankAccount", b =>
                {
                    b.Property<long>("GuildId");

                    b.Property<long>("UserId");

                    b.Property<long>("Currency");

                    b.Property<long>("TotalDeposited");

                    b.HasKey("GuildId", "UserId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("Miki.Models.Objects.Guild.Timer", b =>
                {
                    b.Property<long>("GuildId")
                        .HasColumnName("GuildId");

                    b.Property<long>("UserId")
                        .HasColumnName("UserId");

                    b.Property<DateTime>("Value");

                    b.HasKey("GuildId", "UserId");

                    b.ToTable("Timers");
                });

            modelBuilder.Entity("Miki.Models.PastaVote", b =>
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

            modelBuilder.Entity("Miki.Models.ProfileVisuals", b =>
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

            modelBuilder.Entity("Miki.Models.Setting", b =>
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

            modelBuilder.Entity("Miki.Models.User", b =>
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
                        .HasDefaultValueSql("now()");

                    b.Property<int>("DblVotes")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("HeaderUrl")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("default");

                    b.Property<DateTime>("LastDailyTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now() - interval '1 day'");

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

            modelBuilder.Entity("Miki.Models.UserMarriedTo", b =>
                {
                    b.Property<long>("AskerId");

                    b.Property<long>("ReceiverId");

                    b.Property<long>("MarriageId");

                    b.HasKey("AskerId", "ReceiverId");

                    b.HasIndex("MarriageId")
                        .IsUnique();

                    b.ToTable("UsersMarriedTo");
                });

            modelBuilder.Entity("Miki.Models.Achievement", b =>
                {
                    b.HasOne("Miki.Models.User")
                        .WithMany("Achievements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Miki.Models.CommandUsage", b =>
                {
                    b.HasOne("Miki.Models.User", "User")
                        .WithMany("CommandsUsed")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Miki.Models.Connection", b =>
                {
                    b.HasOne("Miki.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Miki.Models.GlobalPasta", b =>
                {
                    b.HasOne("Miki.Models.User", "User")
                        .WithMany("Pastas")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Miki.Models.LocalExperience", b =>
                {
                    b.HasOne("Miki.Models.User", "User")
                        .WithMany("LocalExperience")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Miki.Models.UserMarriedTo", b =>
                {
                    b.HasOne("Miki.Models.Marriage", "Marriage")
                        .WithOne("Participants")
                        .HasForeignKey("Miki.Models.UserMarriedTo", "MarriageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
