﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonReviewApp.Data;

#nullable disable

namespace PokemonReviewApp.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PokemonReviewApp.Modles.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electric"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Water"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Leaf"
                        });
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kanto"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Saffron City"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Millet Town"
                        });
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gym")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            FirstName = "Jack",
                            Gym = "Brocks Gym",
                            LastName = "London"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            FirstName = "Harry",
                            Gym = "Mistys Gym",
                            LastName = "Potter"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            FirstName = "Ash",
                            Gym = "Ashs Gym",
                            LastName = "Ketchum"
                        });
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1903, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pikachu"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1903, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Squirtle"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1903, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Venasaur"
                        });
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.PokemonCategory", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("PokemonId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PokemonCategories");

                    b.HasData(
                        new
                        {
                            PokemonId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            PokemonId = 2,
                            CategoryId = 2
                        },
                        new
                        {
                            PokemonId = 3,
                            CategoryId = 3
                        });
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.PokemonOwner", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("PokemonId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("PokemonOwners");

                    b.HasData(
                        new
                        {
                            PokemonId = 1,
                            OwnerId = 1
                        },
                        new
                        {
                            PokemonId = 2,
                            OwnerId = 2
                        },
                        new
                        {
                            PokemonId = 3,
                            OwnerId = 3
                        });
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PokemonId = 1,
                            Rating = 5,
                            ReviewerId = 1,
                            Text = "Pikachu is the best pokemon, because it is electric",
                            Title = "Pikachu"
                        },
                        new
                        {
                            Id = 2,
                            PokemonId = 1,
                            Rating = 5,
                            ReviewerId = 2,
                            Text = "Pikachu is the best at killing rocks",
                            Title = "Pikachu"
                        },
                        new
                        {
                            Id = 3,
                            PokemonId = 1,
                            Rating = 1,
                            ReviewerId = 3,
                            Text = "Pikachu, pikachu, pikachu",
                            Title = "Pikachu"
                        },
                        new
                        {
                            Id = 4,
                            PokemonId = 2,
                            Rating = 5,
                            ReviewerId = 1,
                            Text = "Squirtle is the best pokemon, because it is electric",
                            Title = "Squirtle"
                        },
                        new
                        {
                            Id = 5,
                            PokemonId = 2,
                            Rating = 5,
                            ReviewerId = 2,
                            Text = "Squirtle is the best at killing rocks",
                            Title = "Squirtle"
                        },
                        new
                        {
                            Id = 6,
                            PokemonId = 2,
                            Rating = 1,
                            ReviewerId = 3,
                            Text = "Squirtle, squirtle, squirtle",
                            Title = "Squirtle"
                        },
                        new
                        {
                            Id = 7,
                            PokemonId = 3,
                            Rating = 5,
                            ReviewerId = 1,
                            Text = "Venasaur is the best pokemon, because it is electric",
                            Title = "Venasaur"
                        },
                        new
                        {
                            Id = 8,
                            PokemonId = 3,
                            Rating = 5,
                            ReviewerId = 2,
                            Text = "Venasaur is the best at killing rocks",
                            Title = "Venasaur"
                        },
                        new
                        {
                            Id = 9,
                            PokemonId = 3,
                            Rating = 1,
                            ReviewerId = 3,
                            Text = "Venasaur, Venasaur, Venasaur",
                            Title = "Venasaur"
                        });
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reviewers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Teddy",
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Taylor",
                            LastName = "Jones"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Jessica",
                            LastName = "McGregor"
                        });
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.Owner", b =>
                {
                    b.HasOne("PokemonReviewApp.Modles.Country", "Country")
                        .WithMany("Owners")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.PokemonCategory", b =>
                {
                    b.HasOne("PokemonReviewApp.Modles.Category", "Category")
                        .WithMany("PokemonCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonReviewApp.Modles.Pokemon", "Pokemon")
                        .WithMany("PokemonCategories")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.PokemonOwner", b =>
                {
                    b.HasOne("PokemonReviewApp.Modles.Owner", "Owner")
                        .WithMany("PokemonOwners")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonReviewApp.Modles.Pokemon", "Pokemon")
                        .WithMany("PokemonOwners")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.Review", b =>
                {
                    b.HasOne("PokemonReviewApp.Modles.Pokemon", "Pokemon")
                        .WithMany("Reviews")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonReviewApp.Modles.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.Category", b =>
                {
                    b.Navigation("PokemonCategories");
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.Country", b =>
                {
                    b.Navigation("Owners");
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.Owner", b =>
                {
                    b.Navigation("PokemonOwners");
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.Pokemon", b =>
                {
                    b.Navigation("PokemonCategories");

                    b.Navigation("PokemonOwners");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("PokemonReviewApp.Modles.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
