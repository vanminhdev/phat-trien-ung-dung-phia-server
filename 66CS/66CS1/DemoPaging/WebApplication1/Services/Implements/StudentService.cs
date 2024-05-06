using WebApplication1.DbContexts;
using WebApplication1.Dto.Common;
using WebApplication1.Dto.Students;
using WebApplication1.Entity;
using WebApplication1.Exceptions;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Implements
{
    public class StudentService : ClassroomBaseService, IStudentService
    {
        public StudentService(ApplicationDbContext dbContext)
            : base(dbContext) { }

        public StudentDto CreateStudent(CreateStudentDto input)
        {
            var student = new Student
            {
                //Id = ++_dbContext.StudentId,
                Name = input.Name,
                DateOfBirth = input.DateOfBirth,
                StudentCode = input.StudentCode,
                //IsDeleted = false,
            };
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
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
            });
            //foreach (var item in result)
            //{
            //}
            //var results2 = result.ToList();
            return result.ToList();
        }

        public PageResultDto<StudentDto> GetAll(FilterDto input)
        {
            var result = new PageResultDto<StudentDto>();
            var query = _dbContext.Students.Where(e =>
                string.IsNullOrEmpty(input.Keyword)
                || e.Name.ToLower().Contains(input.Keyword.ToLower())
            );

            result.TotalItem = query.Count();
            query = query
                .OrderByDescending(s => s.DateOfBirth) //sắp xếp theo ngày sinh giảm dần và id giảm dần
                .ThenByDescending(s => s.Id)
                .Skip(input.Skip())
                .Take(input.PageSize);

            result.Items = query
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    StudentCode = s.StudentCode,
                    DateOfBirth = s.DateOfBirth
                })
                .ToList();
            return result;
        }

        public void UpdateStudent(UpdateStudentDto input)
        {
            var studentFind = FindStudentById(input.Id);
            studentFind.StudentCode = input.StudentCode;
            studentFind.Name = input.Name;
            studentFind.DateOfBirth = input.DateOfBirth;

            _dbContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var studentFind = FindStudentById(id);
            _dbContext.Students.Remove(studentFind);
            _dbContext.SaveChanges();
        }
    }
}
