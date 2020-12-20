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

                    b.Property<int?>("ShipmentId")
                        .HasColumnType("int");

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

                    b.Property<int?>("ParcelsBagId")
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
                });

            modelBuilder.Entity("API.Model.Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Airport")
                        .HasColumnType("int");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("API.Model.LettersBag", b =>
                {
                    b.HasBaseType("API.Model.Bag");

                    b.Property<int>("LettersCount")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("LettersBag");
                });

            modelBuilder.Entity("API.Model.ParcelsBag", b =>
                {
                    b.HasBaseType("API.Model.Bag");

                    b.HasDiscriminator().HasValue("ParcelsBag");
                });

            modelBuilder.Entity("API.Model.Bag", b =>
                {
                    b.HasOne("API.Model.Shipment", null)
                        .WithMany("bags")
                        .HasForeignKey("ShipmentId");
                });

            modelBuilder.Entity("API.Model.Parcel", b =>
                {
                    b.HasOne("API.Model.ParcelsBag", null)
                        .WithMany("Parcels")
                        .HasForeignKey("ParcelsBagId");
                });

            modelBuilder.Entity("API.Model.Shipment", b =>
                {
                    b.Navigation("bags");
                });

            modelBuilder.Entity("API.Model.ParcelsBag", b =>
                {
                    b.Navigation("Parcels");
                });
#pragma warning restore 612, 618
        }
    }
}
