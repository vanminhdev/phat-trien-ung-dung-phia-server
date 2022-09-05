using Microsoft.AspNetCore.Http;
using WebAPI.Dtos;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        public StudentService(ILogger<StudentService> logger,
            IConfiguration configuration,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _configuration = configuration;
            _dbContext=dbContext;
        }

        public PageResultDto<List<Student>> GetAll(StudentFilterDto input) 
        {
            var studentQuery = _dbContext.Students.AsQueryable();

            if (input.Keyword != null)
            {
                //tìm những phần tử thoả mãn điều kiện
                studentQuery = studentQuery.Where(s => s.Name != null 
                    && s.Name.ToLower().Contains(input.Keyword));
            }
            int totalItem = studentQuery.Count();

            studentQuery = studentQuery.Skip(input.PageSize * (input.PageIndex - 1))
                .Take(input.PageSize);

            return new PageResultDto<List<Student>>
            {
                Items = studentQuery.ToList(),
                TotalItem = totalItem
            };
        }

        public void Create(CreateStudentDto input)
        {
            if (_dbContext.Students.Any(s => s.StudentCode == input.StudentCode))
            {
                throw new Exception($"Mã sinh viên \"{input.StudentCode}\" đã tồn tại");
            }

            string directory = _configuration["App_Data"];
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string path = Path.Combine(directory, input.Avatar.FileName);
            using (var stream = File.Create(path))
            {
                input.Avatar.CopyTo(stream);
            }

            _dbContext.Students.Add(new Student
            {
                Name = input.Name,
                StudentCode = input.StudentCode,
                DateOfBirth = input.DateOfBirth,
                Avatar = path
            });
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateStudentDto input)
        {
            var find = _dbContext.Students.FirstOrDefault(s => s.Id == id);
            if (find == null)
            {
                throw new Exception("Không tìm thấy sinh viên");
            }
            find.Name = input.Name;
            find.StudentCode = input.StudentCode;
            find.DateOfBirth = input.DateOfBirth;
            _dbContext.SaveChanges();
        }
    }
}
