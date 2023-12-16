﻿// <auto-generated />
using System;
using BaseballStatAndScoreTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaseballStatAndScoreTracker.Data.Migrations
{
    [DbContext(typeof(StatTrackerContext))]
    partial class StatTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccountId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Game", b =>
                {
                    b.Property<Guid>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AwayScore")
                        .HasColumnType("int");

                    b.Property<Guid>("AwayTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HomeScore")
                        .HasColumnType("int");

                    b.Property<Guid>("HomeTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GameId");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Inning", b =>
                {
                    b.Property<Guid>("InningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Errors")
                        .HasColumnType("int");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Hits")
                        .HasColumnType("int");

                    b.Property<int>("Runs")
                        .HasColumnType("int");

                    b.HasKey("InningId");

                    b.HasIndex("GameId");

                    b.ToTable("Innings");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Player", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AtBats")
                        .HasColumnType("int");

                    b.Property<int>("Doubles")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HitByPitches")
                        .HasColumnType("int");

                    b.Property<int>("Hits")
                        .HasColumnType("int");

                    b.Property<int>("HomeRuns")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlateAppearances")
                        .HasColumnType("int");

                    b.Property<int>("RBIs")
                        .HasColumnType("int");

                    b.Property<int>("SacFlys")
                        .HasColumnType("int");

                    b.Property<int>("Singles")
                        .HasColumnType("int");

                    b.Property<int>("StrikeOuts")
                        .HasColumnType("int");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Triples")
                        .HasColumnType("int");

                    b.Property<int>("Walks")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Team", b =>
                {
                    b.Property<Guid>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.HasIndex("AccountId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Account", b =>
                {
                    b.HasOne("BaseballStatAndScoreTracker.Domain.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("BaseballStatAndScoreTracker.Domain.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Game", b =>
                {
                    b.HasOne("BaseballStatAndScoreTracker.Domain.Team", "Away")
                        .WithMany("AwayGames")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BaseballStatAndScoreTracker.Domain.Team", "Home")
                        .WithMany("HomeGames")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Away");

                    b.Navigation("Home");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Inning", b =>
                {
                    b.HasOne("BaseballStatAndScoreTracker.Domain.Game", "Game")
                        .WithMany("Innings")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Player", b =>
                {
                    b.HasOne("BaseballStatAndScoreTracker.Domain.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Team", b =>
                {
                    b.HasOne("BaseballStatAndScoreTracker.Domain.Account", "Account")
                        .WithMany("Teams")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Account", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Game", b =>
                {
                    b.Navigation("Innings");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.Team", b =>
                {
                    b.Navigation("AwayGames");

                    b.Navigation("HomeGames");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("BaseballStatAndScoreTracker.Domain.User", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
