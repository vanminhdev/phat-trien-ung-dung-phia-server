using Filter_DCSon.DbContexts;
using Filter_DCSon.Dto;
using Filter_DCSon.Entities;

namespace Filter_DCSon.Services
{
    public class StudentService : IStudentService
    {
        private readonly ILogger _logger;
        private readonly MyDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public StudentService(ILogger<StudentService> logger, MyDbContext dbContext, IConfiguration configuration)
        {
            _logger = logger;
            _logger.LogInformation("vào đây");
            _dbContext = dbContext;
            _configuration = configuration;
        }

        //thêm
        public void CreateStudent(CreateStudentDto input)
        {
            if (_dbContext.Students.FirstOrDefault(s => s.StudentCode == input.StudentCode) != null)
            {
                throw new Exception($"Mã số sinh viên đã tồn tại \"{input.StudentCode}\"đã tồn tại");
            }

            var _student = new Student
            {
                Name = input.Name,
                StudentCode = input.StudentCode,
                DateOfBirth = input.DateOfBirth
            };
            _dbContext.Students.Add(_student);
            _dbContext.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return _dbContext.Students.ToList();
        }

        public PageResultStudentDto GetAllWithPageStudent(StudentFilterDto input)
        {
            //kiểm tra Name có chứa keyword không
            var studentQuery = _dbContext.Students.AsQueryable();

            if (input.Keyword != null)
            {
                studentQuery = studentQuery.Where(s => s.Name != null && s.Name.ToLower().Contains(input.Keyword));
            }
            int totalItem = studentQuery.Count();

            studentQuery = studentQuery.Skip(input.PageSize * (input.PageIndex - 1)).Take(input.PageSize);
            return new PageResultStudentDto
            {
                Items = studentQuery.ToList(),
                TotalItem = totalItem
            };
        }

        public void Update(int id, UpdateStudentDto input)
        {
            var result = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Name = input.Name;
                result.StudentCode = input.StudentCode;
                result.DateOfBirth = input.DateOfBirth;
                _dbContext.SaveChanges();
            } else
            {
                throw new Exception("Không tìm thấy sinh viên");
            }
        }

        public void Delete(int id)
        {
            var result = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                throw new Exception("Không tìm thấy sinh vien");
            }
            _dbContext.Students.Remove(result);
            _dbContext.SaveChanges();
        }

        //xem chi tiết
        public Student GetById(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                throw new Exception("Không tìm thấy sinh viên");
            }
            return student;
        }
    }
}
