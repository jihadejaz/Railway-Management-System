using Microsoft.EntityFrameworkCore;

namespace Railway_Management_System.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<RMSpassengers> Passengers { get; set; }
        public DbSet<trainMaster> TrainMasters { get; set; }
        public DbSet<stationMaster> StationMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define any additional configurations here, such as relationships, indexes, etc.
        }
    }
}
