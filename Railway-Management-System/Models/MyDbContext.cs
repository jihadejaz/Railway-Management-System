using Microsoft.EntityFrameworkCore;

namespace Railway_Management_System.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<RMSpassengers> passengers { get; set; }

    }
}
