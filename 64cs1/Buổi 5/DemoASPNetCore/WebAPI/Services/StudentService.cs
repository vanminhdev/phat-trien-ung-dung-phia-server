using WebAPI.Dto;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class StudentService : IStudentService
    {
        private static int Id = 0;
        private static List<Student> _students = new();
        private readonly ILogger _logger;

        public StudentService(ILogger<StudentService> logger)
        {
            _logger = logger;
            _logger.LogInformation("vào đây");
        }

        //thêm
        public void CreateStudent(CreateStudentDto input)
        {
            _students.Add(new Student
            {
                Id = ++StudentService.Id,
                
            });
        }

        public List<Student> GetAllStudent()
        {
            return _students;
        }

        //sửa

        //xoá

        //xem chi tiết
    }
}
