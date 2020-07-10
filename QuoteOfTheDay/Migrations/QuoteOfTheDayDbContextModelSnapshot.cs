﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuoteOfTheDay.Data;

namespace QuoteOfTheDay.Migrations
{
    [DbContext(typeof(QuoteOfTheDayDbContext))]
    partial class QuoteOfTheDayDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuoteOfTheDay.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuoteCategory")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuoteCategory = 0
                        },
                        new
                        {
                            Id = 2,
                            QuoteCategory = 1
                        },
                        new
                        {
                            Id = 3,
                            QuoteCategory = 2
                        });
                });

            modelBuilder.Entity("QuoteOfTheDay.Domain.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Dr . Seuss",
                            CategoryId = 1,
                            Text = "You’re off to great places, today is your day. Your mountain is waiting, so get on your way."
                        },
                        new
                        {
                            Id = 2,
                            Author = "Groucho Marx",
                            CategoryId = 1,
                            Text = "No one is perfect - that’s why pencils have erasers."
                        },
                        new
                        {
                            Id = 3,
                            Author = "Wolfgang Riebe",
                            CategoryId = 2,
                            Text = "Marriage is the chief cause of divorce."
                        });
                });

            modelBuilder.Entity("QuoteOfTheDay.Domain.Quote", b =>
                {
                    b.HasOne("QuoteOfTheDay.Domain.Category", "Category")
                        .WithMany("Quotes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
