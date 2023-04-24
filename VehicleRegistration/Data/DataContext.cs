using Microsoft.EntityFrameworkCore;
using VehicleRegistration.Models;

namespace VehicleRegistration.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Prefix> Prefixes { get; set; }
        public DbSet<RegistrationNumber> RegistrationNumbers { get; set; }
        public DbSet<Reputation> Reputations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.RegistrationNumber)
                .WithOne(x => x.Vehicle)
                .HasForeignKey<RegistrationNumber>(x => x.VehicleId);

            modelBuilder.Entity<RegistrationNumber>()
                .HasOne(r => r.Vehicle)
                .WithOne(x => x.RegistrationNumber)
                .OnDelete(DeleteBehavior.Cascade);          
        }
    }
}
