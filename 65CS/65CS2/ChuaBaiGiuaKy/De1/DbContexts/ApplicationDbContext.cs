using De1.Entities;
using Microsoft.EntityFrameworkCore;

namespace De1.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}
