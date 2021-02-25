﻿// <auto-generated />
using System;
using GloboTicket.Services.EventCatalog.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GloboTicket.Services.EventCatalog.Migrations
{
    [DbContext(typeof(EventCatalogDbContext))]
    partial class EventCatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("GloboTicket.Services.EventCatalog.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"),
                            Name = "Concerts"
                        },
                        new
                        {
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"),
                            Name = "Musicals"
                        },
                        new
                        {
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea316"),
                            Name = "Plays"
                        });
                });

            modelBuilder.Entity("GloboTicket.Services.EventCatalog.Entities.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Artist")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea317"),
                            Artist = "John Egbert",
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"),
                            Date = new DateTime(2021, 8, 25, 10, 46, 38, 354, DateTimeKind.Local).AddTicks(1705),
                            Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                            ImageUrl = "/img/banjo.jpg",
                            Name = "John Egbert Live",
                            Price = 65
                        },
                        new
                        {
                            EventId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"),
                            Artist = "Michael Johnson",
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"),
                            Date = new DateTime(2021, 11, 25, 10, 46, 38, 360, DateTimeKind.Local).AddTicks(954),
                            Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                            ImageUrl = "/img/michael.jpg",
                            Name = "The State of Affairs: Michael Live!",
                            Price = 85
                        },
                        new
                        {
                            EventId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea318"),
                            Artist = "Nick Sailor",
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"),
                            Date = new DateTime(2021, 10, 25, 10, 46, 38, 360, DateTimeKind.Local).AddTicks(1018),
                            Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                            ImageUrl = "/img/musical.jpg",
                            Name = "To the Moon and Back",
                            Price = 135
                        });
                });

            modelBuilder.Entity("GloboTicket.Services.EventCatalog.Entities.Event", b =>
                {
                    b.HasOne("GloboTicket.Services.EventCatalog.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
