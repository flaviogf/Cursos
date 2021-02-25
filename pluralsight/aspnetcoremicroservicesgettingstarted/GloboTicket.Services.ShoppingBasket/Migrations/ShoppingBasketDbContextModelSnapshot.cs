﻿// <auto-generated />
using System;
using GloboTicket.Services.ShoppingBasket.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GloboTicket.Services.ShoppingBasket.Migrations
{
    [DbContext(typeof(ShoppingBasketDbContext))]
    partial class ShoppingBasketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("GloboTicket.Services.ShoppingBasket.Entities.Basket", b =>
                {
                    b.Property<Guid>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("BasketId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("GloboTicket.Services.ShoppingBasket.Entities.BasketLine", b =>
                {
                    b.Property<Guid>("BasketLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TicketAmount")
                        .HasColumnType("INTEGER");

                    b.HasKey("BasketLineId");

                    b.HasIndex("BasketId");

                    b.HasIndex("EventId");

                    b.ToTable("BasketLines");
                });

            modelBuilder.Entity("GloboTicket.Services.ShoppingBasket.Entities.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("GloboTicket.Services.ShoppingBasket.Entities.BasketLine", b =>
                {
                    b.HasOne("GloboTicket.Services.ShoppingBasket.Entities.Basket", "Basket")
                        .WithMany()
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GloboTicket.Services.ShoppingBasket.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Event");
                });
#pragma warning restore 612, 618
        }
    }
}
