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
            if (ApplicationDbContext1.StudentClassrooms
                .Any(sc => sc.StudentId == studentId && sc.ClassroomId == classroomId))
            {
                throw new Exception("sinh viên đã tồn tại");
            }

            var classroom = ApplicationDbContext1.Classrooms.FirstOrDefault(c => c.Id == classroomId);
            if (classroom == null)
            {
                throw new Exception("Không tìm thấy lớp học");
            }

            int soLuongSinhVien = ApplicationDbContext1.StudentClassrooms.Where(s => s.ClassroomId == classroomId).Count();

            if (classroom.MaxStudent == soLuongSinhVien)
            {
                throw new Exception("Lớp học đã đủ số lượng");
            }

            ApplicationDbContext1.StudentClassrooms.Add(new Entities.StudentClassroom
            {
                Id = ++ApplicationDbContext1.StudentClassroomId,
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
            var studentIds = ApplicationDbContext1.StudentClassrooms
                .Where(sc => sc.ClassroomId == classroomId).Select(sc => sc.StudentId).ToList();

            var students = ApplicationDbContext1.Students.Where(s => studentIds.Contains(s.Id)).ToList();

            //sử dụng join cách 1 dùng method
            var join1 = ApplicationDbContext1.StudentClassrooms.Where(sc => sc.ClassroomId == classroomId)
                .Join(ApplicationDbContext1.Students, sc => sc.StudentId, s => s.Id,
                (studentClassroom, student) => new { student });

            var result1 = join1.Select(o => o.student).ToList();

            //sử dụng join cách 2 dùng keyword
            var join2 = from studentClassroom in ApplicationDbContext1.StudentClassrooms
                       join student in ApplicationDbContext1.Students on studentClassroom.StudentId equals student.Id
                       where studentClassroom.ClassroomId == classroomId
                       select new
                       {
                           student
                       };

            var test = (from s in join2
                        select new Student
                        {
                            Id = s.student.Id,
                            
                        }).ToList();

            var result2 = join2.Select(o => new Student 
            { 
               Id = o.student.Id,
               Name = o.student.Name,
               Avatar = o.student.Avatar
            }).ToList();
            //result1 và result2 cùng cho ra 1 kết quả.

            return students;
        }
    }
}
