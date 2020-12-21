using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<ParcelsBag> ParcelsBags { get; set; }
        public DbSet<LettersBag> LettersBags { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Bag> Bags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<ParcelsBag>();
            // builder.Entity<LettersBag>();

            base.OnModelCreating(builder);

            builder.Entity<Bag>(entity =>
            {
                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.Bags)
                    .HasForeignKey("ShipmentId");
            });

            builder.Entity<Parcel>(entity =>
            {
                entity.HasOne(d => d.ParcelsBag)
                    .WithMany(p => p.Parcels)
                    .HasForeignKey("ParcelsBagId");
            });

            Shipment shipment = new Shipment
            {
                Id = 1,
                Number = "rtysdf",
                Airport = Enumerations.Airport.TLL,
                FlightNumber = "dfsfdsf",
                FlightDate = DateTime.Now
            };
            ParcelsBag parcelsBag = new ParcelsBag { Id = 1, Number = "AAA445", ShipmentId = 1 };
            LettersBag lettersBag = new LettersBag
            {
                Id = 2,
                Number = "HHDF53",
                LettersCount = 34,
                Weight = 4.56,
                Price = 6.56,
                ShipmentId = 1
            };

            Parcel parcel = new Parcel
            {
                Id = 1,
                Number = "1DD45",
                RecipientName = "Michael",
                DestinationCountry = "USA",
                Weight = 2.45,
                Price = 3.45,
                ParcelsBagId = 1
            };
            // shipment.Bags.Add(parcelsBag);
            // shipment.Bags.Add(lettersBag);
            // parcelsBag.Parcels.Add(parcel);

            builder.Entity<ParcelsBag>().HasData(parcelsBag);

            builder.Entity<LettersBag>().HasData(lettersBag);

            builder.Entity<Shipment>().HasData(shipment);

            builder.Entity<Parcel>().HasData(parcel);
        }
    }
}