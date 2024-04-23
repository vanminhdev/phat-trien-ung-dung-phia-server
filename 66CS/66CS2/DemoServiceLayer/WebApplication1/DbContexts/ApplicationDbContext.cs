using Microsoft.EntityFrameworkCore;
using WebApplication1.Entity;

namespace WebApplication1.DbContexts
{
    /// <summary>
    /// Dùng để kết nối db
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<StudentClassroom> StudentClasses { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //map entity với bảng
            //cách 1
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student"); //Option
                entity.HasKey(e => e.Id);
                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id") //Option
                    .ValueGeneratedOnAdd() //identity(1,1)
                    .IsRequired(); //required field
                entity.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired();
            });

            //cách 2 cấu hình trong entity

            //khoá ngoại

            //cách 1:
            modelBuilder
                .Entity<StudentClassroom>() //”Class many”
                .HasOne<Student>() //”class one”
                .WithMany()
                .HasForeignKey(sc => sc.StudentId);

            //cách 2:
            //modelBuilder.Entity<Student>()
            //    .HasMany<StudentClassroom>()
            //    .WithOne()
            //    .HasForeignKey(sc => sc.StudentId);

            //navigation property ?
        }
    }
}
