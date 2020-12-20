using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Parcel> Parcels { get; set; }
        //public DbSet<ParcelsBag> ParcelsBags { get; set; }
        //public DbSet<LettersBag> LettersBags { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Bag> Bags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<ParcelsBag>();
        builder.Entity<LettersBag>();

        base.OnModelCreating(builder);
        }
    }
}