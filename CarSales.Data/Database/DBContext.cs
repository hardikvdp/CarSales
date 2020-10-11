using CarSales.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Data.Database
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }

        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }
    }
}
