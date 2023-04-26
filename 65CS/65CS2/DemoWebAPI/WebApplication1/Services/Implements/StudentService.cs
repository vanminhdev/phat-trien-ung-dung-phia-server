using WebApplication1.Dto.Student;
using WebApplication1.Entities;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implements
{
    public class StudentService : IStudentService
    {
        private static List<Student> _students = new List<Student>();
        private static int _id = 0;

        //thêm, sửa, xoá, xem danh sách

        public void Create(CreateStudentDto input)
        {
            // thêm sinh viên vào list
            _students.Add(new Student
            {
                Id = _id++,
                //Name = input.Name,
            });
        }

        public void Update(UpdateStudentDto input)
        {
            var student = _students.FirstOrDefault(s => s.Id == input.Id);
            if (student == null)
            {
                throw new Exception($"Không tìm thấy sinh viên có id = {input.Id}");
            }
            student.Name = input.Name;
            student.Age = input.Age;
        }

        public List<StudentDto> GetAll()
        {
            var results = new List<StudentDto>();
            foreach (var student in _students)
            {
                results.Add(new StudentDto 
                { 
                    Id = student.Id,
                    Name = student.Name,
                    Age = student.Age
                });
            }
            return results;
        }
    }
}
