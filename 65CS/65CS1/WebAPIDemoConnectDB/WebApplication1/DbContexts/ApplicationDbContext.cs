using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<StudentClassroom> StudentClassrooms { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //dùng Fluent API,

            //dùng các attribute annotations
        }
    }
}
