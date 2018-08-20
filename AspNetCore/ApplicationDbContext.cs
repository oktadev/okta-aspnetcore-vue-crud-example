using Microsoft.EntityFrameworkCore;

namespace AspNetCore
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<FoodRecord> FoodRecords { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
    }
}