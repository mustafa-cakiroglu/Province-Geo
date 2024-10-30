using Microsoft.EntityFrameworkCore;
using ProvinceTest.Model;

namespace ProvinceTest
{
    public class ApplicationDbContext : DbContext
    {
        public static readonly string DefaultSchema = "Common";

        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(DefaultSchema);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User Id=postgres;Host=***;Port=5432;Password=***;Database=VoeZone;NoResetOnClose=true;");

        }
    }
}
