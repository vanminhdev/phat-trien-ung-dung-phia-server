using WebApplication1.Entities;

namespace WebApplication1.DbContexts
{
    public class ApplicationDbContext
    {
        public List<Classroom> Classrooms = new();
        public int ClassroomId = 0;

        public List<StudentClassroom> StudentClassroom = new();
        public int StuClassId = 0;

        public List<Student> Students = new List<Student>();
        public int StudentId = 0;
    }
}
