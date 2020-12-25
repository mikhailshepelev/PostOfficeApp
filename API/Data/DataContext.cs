using API.Model;
using Microsoft.EntityFrameworkCore;
using System;

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

            builder.Entity<Bag>().Property("Discriminator");

            builder.Entity<Shipment>().Property(t => t.Number).IsRequired();
            builder.Entity<Shipment>().HasIndex(u => u.Number).IsUnique();
            builder.Entity<Shipment>().Property(t => t.Airport).IsRequired();
            builder.Entity<Shipment>().Property(t => t.FlightNumber).IsRequired();
            builder.Entity<Shipment>().Property(t => t.FlightDate).IsRequired();

            builder.Entity<LettersBag>().Property(m => m.Weight).HasPrecision(18, 3);

            seedDatabase(builder);
        }

        public void seedDatabase(ModelBuilder builder)
        {
            Shipment shipment = new Shipment
            {
                Id = 1,
                Number = "rtysdf",
                Airport = "TLL",
                FlightNumber = "dfsfdsf",
                FlightDate = DateTime.Now,
                isFinalized = false
            };
            ParcelsBag parcelsBag = new ParcelsBag { Id = 1, Number = "AAA445", ShipmentId = 1 };
            LettersBag lettersBag = new LettersBag
            {
                Id = 2,
                Number = "HHDF53",
                LettersCount = 34,
                Weight = 4.563M,
                Price = 6.56M,
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

            builder.Entity<ParcelsBag>().HasData(parcelsBag);
            builder.Entity<LettersBag>().HasData(lettersBag);
            builder.Entity<Shipment>().HasData(shipment);
            builder.Entity<Parcel>().HasData(parcel);
        }
    }
}