using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.DbContexts
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        //public DbSet<Classroom> Classrooms { get; set; }
        //public DbSet<StudentClassroom> StudentClassrooms { get; set; }

        public StudentDbContext(DbContextOptions options) : base(options) 
        { 
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        //{
        //    //thêm connection string ở đây
        //}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //map các trường dữ liệu của các entity vào các table tương ứng

            modelBuilder.Entity<Student>(entity =>
            {
                //entity.ToTable("Student"); //Option
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    //.HasColumnName("Id") //Option
                    .ValueGeneratedOnAdd() //identity(1,1)
                    .IsRequired(); //required field

                entity.Property(e => e.Name)
                    //.HasColumnType("nvarchar(50)")
                    .HasMaxLength(200)
                    .IsUnicode()
                    .IsRequired();

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.Avatar)
                    .HasColumnType("nvarchar(256)")
                    .IsRequired();
            });
        }
    }
}
