using Filter_DCSon.Entities;

namespace Filter_DCSon.DbContexts
{
    public class ApplicationDbContext
    {
        //student
        public static int StudentId = 0;
        public static List<Student> Students = new();

        //classroom
        public static int ClassroomId = 0;
        public static List<Subject> Classrooms = new();

        //quan hệ student và classroom
        public static int StudentClassroomId = 0;
        public static List<StudentSubject> StudentClassrooms = new();
    }
}
