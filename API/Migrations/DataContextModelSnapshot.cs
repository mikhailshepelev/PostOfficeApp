﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("API.Model.Bag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("int");

                    b.Property<bool>("isFinalized")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ShipmentId");

                    b.ToTable("Bags");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Bag");
                });

            modelBuilder.Entity("API.Model.Parcel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DestinationCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParcelsBagId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("RecipientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ParcelsBagId");

                    b.ToTable("Parcels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DestinationCountry = "USA",
                            Number = "1DD45",
                            ParcelsBagId = 1,
                            Price = 3.4500000000000002,
                            RecipientName = "Michael",
                            Weight = 2.4500000000000002
                        });
                });

            modelBuilder.Entity("API.Model.Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Airport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("bagsCount")
                        .HasColumnType("int");

                    b.Property<int>("countOfBagsWithoutParcels")
                        .HasColumnType("int");

                    b.Property<bool>("isFinalized")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Shipments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Airport = "TLL",
                            FlightDate = new DateTime(2020, 12, 31, 16, 7, 53, 123, DateTimeKind.Local).AddTicks(220),
                            FlightNumber = "dfsfdsf",
                            Number = "rtysdf",
                            bagsCount = 0,
                            countOfBagsWithoutParcels = 0,
                            isFinalized = false
                        });
                });

            modelBuilder.Entity("API.Model.LettersBag", b =>
                {
                    b.HasBaseType("API.Model.Bag");

                    b.Property<int>("LettersCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Weight")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.HasDiscriminator().HasValue("LettersBag");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Number = "HHDF53",
                            ShipmentId = 1,
                            isFinalized = false,
                            LettersCount = 34,
                            Price = 6.56m,
                            Weight = 4.563m
                        });
                });

            modelBuilder.Entity("API.Model.ParcelsBag", b =>
                {
                    b.HasBaseType("API.Model.Bag");

                    b.Property<int>("ParcelsCount")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ParcelsBag");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = "AAA445",
                            ShipmentId = 1,
                            isFinalized = false,
                            ParcelsCount = 0
                        });
                });

            modelBuilder.Entity("API.Model.Bag", b =>
                {
                    b.HasOne("API.Model.Shipment", "Shipment")
                        .WithMany("Bags")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("API.Model.Parcel", b =>
                {
                    b.HasOne("API.Model.ParcelsBag", "ParcelsBag")
                        .WithMany("Parcels")
                        .HasForeignKey("ParcelsBagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParcelsBag");
                });

            modelBuilder.Entity("API.Model.Shipment", b =>
                {
                    b.Navigation("Bags");
                });

            modelBuilder.Entity("API.Model.ParcelsBag", b =>
                {
                    b.Navigation("Parcels");
                });
#pragma warning restore 612, 618
        }
    }
}
