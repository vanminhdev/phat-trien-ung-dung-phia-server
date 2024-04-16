using WebApplication1.Entity;

namespace WebApplication1.DbContexts
{
    /// <summary>
    /// Dùng để kết nối db
    /// </summary>
    public class ApplicationDbContext
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public int StudentId { get; set; } = 0;
        public List<Classroom> Classrooms { get; set; } = new();
        public int ClassroomId { get; set; } = 0;
        public List<StudentClassroom> StudentClasses { get; set; } = new();
        public int StudentClassroomId { get; set; } = 0;

        public ApplicationDbContext()
        {
        }
    }
}
