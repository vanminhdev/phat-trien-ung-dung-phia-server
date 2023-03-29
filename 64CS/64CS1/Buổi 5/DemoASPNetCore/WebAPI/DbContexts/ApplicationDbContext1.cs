using WebAPI.Entities;

namespace WebAPI.DbContexts
{
    public class ApplicationDbContext1
    {
        //student
        public static int StudentId = 0;
        public static List<Student> Students = new();

        //classroom
        public static int ClassroomId = 0;
        public static List<Classroom> Classrooms = new();

        //quan hệ student và classroom
        public static int StudentClassroomId = 0;
        public static List<StudentClassroom> StudentClassrooms = new();
    }
}
