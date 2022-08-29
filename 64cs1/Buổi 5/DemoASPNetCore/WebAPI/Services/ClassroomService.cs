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

        /// <summary>
        /// Thêm sinh viên vào lớp
        /// </summary>
        /// <param name="classroomId"></param>
        /// <param name="studentId"></param>
        /// <exception cref="Exception"></exception>
        public void AddStudent(int classroomId, int studentId)
        {
            //kiểm tra sinh viên đã có trong lớp
            if (ApplicationDbContext.StudentClassrooms
                .Any(sc => sc.StudentId == studentId && sc.ClassroomId == classroomId))
            {
                throw new Exception("sinh viên đã tồn tại");
            }

            var classroom = ApplicationDbContext.Classrooms.FirstOrDefault(c => c.Id == classroomId);
            if (classroom == null)
            {
                throw new Exception("Không tìm thấy lớp học");
            }

            int soLuongSinhVien = ApplicationDbContext.StudentClassrooms.Where(s => s.ClassroomId == classroomId).Count();

            if (classroom.MaxStudent == soLuongSinhVien)
            {
                throw new Exception("Lớp học đã đủ số lượng");
            }

            ApplicationDbContext.StudentClassrooms.Add(new Entities.StudentClassroom
            {
                Id = ++ApplicationDbContext.StudentClassroomId,
                ClassroomId = classroomId,
                StudentId = studentId
            });
        }

        /// <summary>
        /// Danh sách sinh viên trong lớp.
        /// </summary>
        /// <param name="classroomId"></param>
        /// <returns></returns>
        public List<Student> GetStudentByClassroom(int classroomId)
        {
            var studentIds = ApplicationDbContext.StudentClassrooms
                .Where(sc => sc.ClassroomId == classroomId).Select(sc => sc.StudentId).ToList();

            var students = ApplicationDbContext.Students.Where(s => studentIds.Contains(s.Id)).ToList();

            return students;
        }
    }
}
