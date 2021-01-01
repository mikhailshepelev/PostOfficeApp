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

            builder.Entity<LettersBag>().Property(m => m.Weight).HasPrecision(18, 3);
            builder.Entity<Parcel>().Property(m => m.Weight).HasPrecision(18, 3);

            seedDatabase(builder);
        }

        public void seedDatabase(ModelBuilder builder)
        {
            Shipment shipment = new Shipment
            {
                Id = 1,
                Number = "ADN-769096",
                Airport = "TLL",
                FlightNumber = "TY8765",
                FlightDate = DateTime.Now.AddMonths(1),
            };
            ParcelsBag parcelsBag = new ParcelsBag { Id = 1, Number = "JK78", ShipmentId = 1, ParcelsCount = 1 };
            LettersBag lettersBag = new LettersBag
            {
                Id = 2,
                Number = "UY01",
                LettersCount = 34,
                Weight = 4.563M,
                Price = 6.56M,
                ShipmentId = 1
            };

            Parcel parcel = new Parcel
            {
                Id = 1,
                Number = "NJ905612UM",
                RecipientName = "John Appleseed",
                DestinationCountry = "US",
                Weight = 2.459M,
                Price = 3.45M,
                ParcelsBagId = 1
            };

            builder.Entity<ParcelsBag>().HasData(parcelsBag);
            builder.Entity<LettersBag>().HasData(lettersBag);
            builder.Entity<Shipment>().HasData(shipment);
            builder.Entity<Parcel>().HasData(parcel);
        }
    }
}