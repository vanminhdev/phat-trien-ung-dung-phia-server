using WebApplication1.DbContexts;
using WebApplication1.Dto.Students;
using WebApplication1.Entity;
using WebApplication1.Exceptions;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Implements
{
    public class StudentService : ClassroomBaseService, IStudentService
    {
        public StudentService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public StudentDto CreateStudent(CreateStudentDto input)
        {
            var student = new Student
            {
                Id = ++_dbContext.StudentId,
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
            var studentFind = FindStudentById(input.Id);
            studentFind.StudentCode = input.StudentCode;
            studentFind.Name = input.Name;
            studentFind.DateOfBirth = input.DateOfBirth;
        }
    }
}
