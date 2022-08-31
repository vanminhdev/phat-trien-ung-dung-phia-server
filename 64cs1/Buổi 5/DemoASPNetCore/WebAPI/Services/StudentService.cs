using WebAPI.DbContexts;
using WebAPI.Dto;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly ILogger _logger;

        public StudentService(ILogger<StudentService> logger)
        {
            _logger = logger;
            _logger.LogInformation("vào đây");
        }

        //thêm
        public void CreateStudent(CreateStudentDto input)
        {
            throw new Exception("lỗi thêm sinh viên");

            ApplicationDbContext.Students.Add(new Student
            {
                Id = ++ApplicationDbContext.StudentId,
                
            });
        }

        public PageResultStudentDto GetAllStudent(StudentFilterDto input)
        {
            //kiểm tra Name có chứa keyword không
            var students = ApplicationDbContext.Students;

            if (input.Keyword != null) //nếu keyword khác null
            {
                students = ApplicationDbContext.Students
                    //kiểm tra nếu Name khác null, nếu Name có chứa ký tự trong keyword
                    .Where(s => s.Name != null && s.Name.Contains(input.Keyword))
                    .ToList();
            }

            int totalItem = students.Count;

            //chia trang
            students = students
                .Skip(input.PageSize * (input.PageIndex - 1))
                .Take(input.PageSize)
                .ToList();

            return new PageResultStudentDto
            {
                Items = students,
                TotalItem = totalItem
            };
        }

        //sửa

        //xoá

        //xem chi tiết
    }
}
