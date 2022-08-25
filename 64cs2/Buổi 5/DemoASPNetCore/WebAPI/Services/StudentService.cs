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

        public PageResultDto<List<Student>> GetAll(StudentFilterDto input) 
        {
            var students = _students;

            if (input.Keyword != null)
            {
                //tìm những phần tử thoả mãn điều kiện
                students = students.Where(s => s.Name != null 
                    && s.Name.ToLower().Contains(input.Keyword?.ToLower()))
                    .ToList();
            }
            int totalItem = students.Count();

            students = students.Skip(input.PageSize * (input.PageIndex - 1))
                .Take(input.PageSize)
                .ToList();

            return new PageResultDto<List<Student>>
            {
                Items = students,
                TotalItem = totalItem
            };
        }

        public void Create(CreateStudentDto input)
        {
            if (_students.Any(s => s.StudentCode == input.StudentCode))
            {
                throw new Exception($"Mã sinh viên \"{input.StudentCode}\" đã tồn tại");
            }

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
