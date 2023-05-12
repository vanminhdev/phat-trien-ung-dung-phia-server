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
            //map các trường trong entity với csdl
            //cách 1: dùng Fluent API,
            //modelBuilder.Entity<Student>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Name)
            //        .IsUnicode()
            //        .HasMaxLength(100)
            //        .IsRequired();
            //    //các trường còn lại viết tiếp
            //});

            modelBuilder.Entity<StudentClassroom>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<StudentClassroom>()
                  .HasOne<Classroom>()
                  .WithMany()
                  .HasForeignKey(e => e.ClassroomId);

            //cách 2: dùng các attribute annotations sẽ viết bên trong các class entity
        }
    }
}
