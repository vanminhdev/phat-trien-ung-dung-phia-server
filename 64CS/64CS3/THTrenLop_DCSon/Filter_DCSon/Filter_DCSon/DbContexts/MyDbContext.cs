using Filter_DCSon.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filter_DCSon.DbContexts
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }


        #region DbSet
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student"); 
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd() // identity (1,1)
                    .IsRequired();
                entity.Property(e => e.Name)
                    .IsUnicode()
                    .HasMaxLength(200)
                    .IsRequired();
                entity.Property(e => e.StudentCode)
                    .IsUnicode()
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .IsRequired();
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");  // Option
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd() // identity (1,1)
                    .IsRequired();
                entity.Property(e => e.Name)
                    .IsUnicode()
                    .HasMaxLength(200)
                    .IsRequired();
                entity.Property(e => e.SubjectCode)
                    .IsUnicode()
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.NumberCredits)
                    .IsRequired();
            });

            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity.ToTable("StudentSubject");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd() // identity (1,1)
                    .IsRequired();
                entity.Property(e => e.Score)
                    .IsRequired();

                entity.HasOne(e => e.Student)
                    .WithMany(e => e.StudentSubjects)
                    .HasForeignKey(e => e.StudentId)
                    .HasConstraintName("FK_SS_Student");

                entity.HasOne(e => e.Subject)
                    .WithMany(e => e.StudentSubjects)
                    .HasForeignKey(e => e.SubjectId)
                    .HasConstraintName("FK_SS_Subject");
            });
        }
    }
}
