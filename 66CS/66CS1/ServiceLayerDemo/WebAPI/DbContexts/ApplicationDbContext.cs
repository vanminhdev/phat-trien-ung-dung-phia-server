using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<StudentClassroom> StudentClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>(entity =>
            //{
            //    entity.ToTable("Student"); //Option
            //    entity.HasKey(e => e.Id);
            //    entity
            //        .Property(e => e.Id)
            //        .HasColumnName("Id") //Option
            //        .ValueGeneratedOnAdd() //identity(1,1)
            //        .IsRequired(); //required field
            //    entity.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired();
            //});

            //cách 1:
            modelBuilder.Entity<StudentClassroom>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(sc => sc.StudentId);

            //cách 2:
            modelBuilder.Entity<Student>()
                .HasMany<StudentClassroom>()
                .WithOne()
                .HasForeignKey(sc => sc.StudentId);
        }
    }
}
