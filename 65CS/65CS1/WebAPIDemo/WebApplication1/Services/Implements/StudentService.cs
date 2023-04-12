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
    }
}
