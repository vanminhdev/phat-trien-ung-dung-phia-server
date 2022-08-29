using WebAPI.DbContexts;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class ClassroomService
    {
        private readonly ILogger _logger;

        public ClassroomService(ILogger<ClassroomService> logger)
        {
            _logger = logger;
        }

        public void AddStudent(int classroomId, int studentId)
        {
            //kiểm tra sinh viên đã có trong lớp
            if (ApplicationDbContext.StudentClassrooms
                .Any(sc => sc.StudentId == studentId && sc.ClassroomId == classroomId))
            {
                throw new Exception("sinh viên đã tồn tại");
            }

            ApplicationDbContext.StudentClassrooms.Add(new Entities.StudentClassroom
            {
                Id = ++ApplicationDbContext.StudentClassroomId,
                ClassroomId = classroomId,
                StudentId = studentId
            });
        }

        public List<Student> GetStudentByClassroom(int classroomId)
        {
            var studentIds = ApplicationDbContext.StudentClassrooms
                .Where(sc => sc.ClassroomId == classroomId).Select(sc => sc.StudentId).ToList();

            var students = ApplicationDbContext.Students.Where(s => studentIds.Contains(s.Id)).ToList();

            return students;
        }
    }
}
