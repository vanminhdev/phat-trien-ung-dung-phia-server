using Microsoft.EntityFrameworkCore;
using WebApplication3.Entities;

namespace WebApplication3.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
                entity.Property(e => e.Name)
                   .IsUnicode()
                   .HasMaxLength(50)
                   .IsRequired();
                entity.Property(e => e.StudentCode)
                    .IsUnicode()
                    .HasMaxLength(20)
                    .IsRequired();
                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .IsRequired();
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
                entity.Property(e => e.SubjectCode)
                    .IsUnicode()
                    .HasMaxLength(20)
                    .IsRequired();
                entity.Property(e => e.SubjectName)
                    .IsUnicode()
                    .HasMaxLength(50)
                    .IsRequired();
            });

            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity.HasOne<Subject>()
                    .WithMany()
                    .HasForeignKey(p => p.SubjectId);
                entity.HasOne<Student>()
                    .WithMany()
                    .HasForeignKey(p => p.StudentId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
                entity.Property(e => e.Username)
                    .IsUnicode(false)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.Password)
                    .IsUnicode()
                    .HasMaxLength(100)
                    .IsRequired();
            });
        }
    }
}
