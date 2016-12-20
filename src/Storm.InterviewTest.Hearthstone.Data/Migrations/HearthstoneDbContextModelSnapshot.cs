using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Storm.InterviewTest.Hearthstone.Data;
using Storm.InterviewTest.Hearthstone.Data.Domain;

namespace Storm.InterviewTest.Hearthstone.Data.Migrations
{
    [DbContext(typeof(HearthstoneDbContext))]
    partial class HearthstoneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Storm.InterviewTest.Hearthstone.Data.Domain.Card", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Attack");

                    b.Property<int>("Cost");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Faction");

                    b.Property<string>("Name");

                    b.Property<string>("PlayerClass");

                    b.Property<int>("Rarity");

                    b.Property<string>("Text");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Card");
                });

            modelBuilder.Entity("Storm.InterviewTest.Hearthstone.Data.Domain.MinionCard", b =>
                {
                    b.HasBaseType("Storm.InterviewTest.Hearthstone.Data.Domain.Card");

                    b.Property<int>("Health");

                    b.ToTable("MinionCard");

                    b.HasDiscriminator().HasValue("MinionCard");
                });

            modelBuilder.Entity("Storm.InterviewTest.Hearthstone.Data.Domain.SpellCard", b =>
                {
                    b.HasBaseType("Storm.InterviewTest.Hearthstone.Data.Domain.Card");


                    b.ToTable("SpellCard");

                    b.HasDiscriminator().HasValue("SpellCard");
                });

            modelBuilder.Entity("Storm.InterviewTest.Hearthstone.Data.Domain.WeaponCard", b =>
                {
                    b.HasBaseType("Storm.InterviewTest.Hearthstone.Data.Domain.Card");

                    b.Property<int>("Durability");

                    b.ToTable("WeaponCard");

                    b.HasDiscriminator().HasValue("WeaponCard");
                });

            modelBuilder.Entity("Storm.InterviewTest.Hearthstone.Data.Domain.HeroCard", b =>
                {
                    b.HasBaseType("Storm.InterviewTest.Hearthstone.Data.Domain.MinionCard");


                    b.ToTable("HeroCard");

                    b.HasDiscriminator().HasValue("HeroCard");
                });
        }
    }
}
