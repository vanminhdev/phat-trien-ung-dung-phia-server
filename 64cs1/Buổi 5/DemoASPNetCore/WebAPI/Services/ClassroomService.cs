using WebAPI.DbContexts;
using WebAPI.Dto;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class ClassroomService : IClassroomService
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

        public void AddListStudent(AddListStudentDto input)
        {
            //xử lý thêm danh sách sinh viên
            foreach (var studentId in input.StudentIds)
            {

            }
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

            //sử dụng join cách 1 dùng method
            var join1 = ApplicationDbContext.StudentClassrooms.Where(sc => sc.ClassroomId == classroomId)
                .Join(ApplicationDbContext.Students, sc => sc.StudentId, s => s.Id,
                (studentClassroom, student) => new { student });

            var result1 = join1.Select(o => o.student).ToList();

            //sử dụng join cách 2 dùng syntax
            var join2 = from studentClassroom in ApplicationDbContext.StudentClassrooms
                       join student in ApplicationDbContext.Students on studentClassroom.StudentId equals student.Id
                       where studentClassroom.ClassroomId == classroomId
                       select new
                       {
                           student
                       };

            var result2 = join2.Select(o => o.student).ToList();
            //result1 và result2 cùng cho ra 1 kết quả.

            return students;
        }
    }
}
