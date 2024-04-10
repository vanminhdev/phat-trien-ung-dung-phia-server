using WebApplication1.DbContexts;
using WebApplication1.Dto;
using WebApplication1.Entity;
using WebApplication1.Exceptions;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Implements
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

        public void UpdateStudent(UpdateStudentDto input)
        {
            var studentFind = _students.Find(s => s.Id == input.Id && !s.IsDeleted);
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
