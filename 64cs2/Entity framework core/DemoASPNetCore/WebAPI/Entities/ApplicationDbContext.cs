using Microsoft.EntityFrameworkCore;

namespace WebAPI.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; }
        //public DbSet<Classroom> Classrooms { get; }
        //public DbSet<StudentClassroom> StudentClassrooms { get; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //dotnet ef dbcontext scaffold "Data Source=.\SQLEXPRESS;Initial Catalog=DemoManagerStudent;Integrated Security=True;Pooling=False" Microsoft.EntityFrameworkCore.SqlServer -o Entities2 -f

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student"); //Option
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    //.HasColumnName("Id") //Option
                    .ValueGeneratedOnAdd() //identity(1,1)
                    .IsRequired(); //required field

                entity.Property(e => e.Name)
                    .IsUnicode()
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.StudentCode)
                    .IsUnicode()
                    .HasMaxLength(50)
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
