using WebAPI.Entities;

namespace WebAPI.DbContexts
{
    public class ApplicationDbContext
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public int StudentId { get; set; } = 0;

        public List<Classroom> Classrooms { get; set; }
        public int ClassroomId { get; set; } = 0;

        public List<StudentClassroom> StudentClasses { get; set; }
        public int StudentClassroomId { get; set; } = 0;

        public ApplicationDbContext()
        {
        }
    }
}
