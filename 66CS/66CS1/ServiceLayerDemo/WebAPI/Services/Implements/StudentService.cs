using WebAPI.DbContexts;
using WebAPI.Dtos.Students;
using WebAPI.Entities;
using WebAPI.Exceptions;
using WebAPI.Services.Abstract;

namespace WebAPI.Services.Implements
{
    public class StudentService : IStudentService
    {
        private static List<Student> _students = new List<Student>();
        private static int _id = 0;
        private readonly ApplicationDbContext _dbContext;

        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student CreateStudent(CreateStudentDto input)
        {
            var student = new Student
            {
                Id = ++_id,
                Name = input.Name,
                DateOfBirth = input.DateOfBirth,
            };

            _students.Add(student);
            return student;
        }

        public void UpdateStudent(UpdateStudentDto student)
        {
            var findStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (findStudent == null)
            {
                //báo lỗi
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id là {student.Id}");
            }
            else
            {
                findStudent.Name = student.Name;
                findStudent.DateOfBirth = student.DateOfBirth;
            }

            //có thêm ngoại lệ
            // throw new Ex
        }
    }
}
