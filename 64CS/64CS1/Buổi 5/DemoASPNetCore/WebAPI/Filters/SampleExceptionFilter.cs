using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;
using System.Data;

namespace WebAPI.Filters
{
    public class SampleExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult
            {
                Content = context.Exception.Message,
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
    }


    public class ApplicationDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Student>()
                    .Property(s => s.Id)
                    .HasColumnName("Id")
                    .HasDefaultValue(0)
                    .IsRequired();

            //Fluent API method chained calls
            modelBuilder.Entity<Student>()
                    .Property(s => s.Id)
                    .HasColumnName("Id")
                    .HasDefaultValue(0)
                    .IsRequired();

            //Separate method calls
            modelBuilder.Entity<Student>().Property(s => s.Id).HasColumnName("Id");
            modelBuilder.Entity<Student>().Property(s => s.Id).HasDefaultValue(0);
            modelBuilder.Entity<Student>().Property(s => s.Id).IsRequired();

            modelBuilder.Entity<StudentClassroom>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(p => p.StudentId);


            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student"); //Option
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("Id") //Option
                    .ValueGeneratedOnAdd() //identity(1,1)
                    .IsRequired(); //required field

                entity.Property(e => e.Name)
                    .HasColumnType("nvarchar(50)")
                    .IsRequired();

                entity.Property(e => e.Avatar)
                    .HasColumnType("nvarchar(256)")
                    .IsRequired(false);
            });
        }
    }
}
