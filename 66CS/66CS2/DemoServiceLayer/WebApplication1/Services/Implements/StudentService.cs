using WebApplication1.DbContexts;
using WebApplication1.Dto;
using WebApplication1.Entity;
using WebApplication1.Exceptions;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Implements
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StudentDto CreateStudent(CreateStudentDto input)
        {
            var student = new Student
            {
                Id = ++_dbContext.Id,
                Name = input.Name,
                DateOfBirth = input.DateOfBirth,
                StudentCode = input.StudentCode,
                //IsDeleted = false,
            };
            _dbContext.Students.Add(student);
            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                StudentCode = student.StudentCode,
                DateOfBirth = student.DateOfBirth,
            };
        }

        public List<StudentDto> GetAll()
        {
            var result = _dbContext.Students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                StudentCode = s.StudentCode,
                DateOfBirth = s.DateOfBirth
            }).ToList();
            return result;
        }

        public void UpdateStudent(UpdateStudentDto input)
        {
            var studentFind = _dbContext.Students.Find(s => s.Id == input.Id && !s.IsDeleted);
            if (studentFind == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id {input.Id}");
            }

            studentFind.StudentCode = input.StudentCode;
            studentFind.Name = input.Name;
            studentFind.DateOfBirth = input.DateOfBirth;

        }


    }
}
