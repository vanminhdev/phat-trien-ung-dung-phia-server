using WebAPI.Dtos;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class StudentService : IStudentService
    {
        private static int _id = 0;
        private static List<Student> _students = new();

        public StudentService()
        {
        }

        public List<Student> GetAll() 
        {
            return _students;
        }

        public void Create(CreateStudentDto input)
        {
            _students.Add(new Student
            {
                Id = ++_id,
                Name = input.Name,
                StudentCode = input.StudentCode,
                DateOfBirth = input.DateOfBirth
            });
        }

        public void Update(int id, UpdateStudentDto input)
        {
            var find = _students.FirstOrDefault(s => s.Id == id);
            if (find == null)
            {
                throw new Exception("Không tìm thấy sinh viên");
            }
            find.Name = input.Name;
            find.StudentCode = input.StudentCode;
            find.DateOfBirth = input.DateOfBirth;
        }
    }
}
