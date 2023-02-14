﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission6_tcp44.Models;

namespace Mission6_tcp44.Migrations
{
    [DbContext(typeof(MovieLibraryDatabaseContext))]
    [Migration("20230214053115_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("Mission6_tcp44.Models.MovieEntry", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId");

                    b.ToTable("responses");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Category = "Comedy",
                            Director = "John",
                            Edited = true,
                            Lent = "my sister",
                            Notes = "This is a great show!",
                            Rating = "PG-13",
                            Title = "Get Smart",
                            Year = 2004
                        },
                        new
                        {
                            MovieId = 2,
                            Category = "Comedy",
                            Director = "Matt",
                            Edited = false,
                            Lent = "dad",
                            Notes = "Super funny!",
                            Rating = "PG-13",
                            Title = "Nacho Libre",
                            Year = 2005
                        },
                        new
                        {
                            MovieId = 3,
                            Category = "Adventure",
                            Director = "Smithson",
                            Edited = false,
                            Lent = "mom",
                            Notes = "One of the greats!",
                            Rating = "PG-13",
                            Title = "Top Gun",
                            Year = 2022
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
