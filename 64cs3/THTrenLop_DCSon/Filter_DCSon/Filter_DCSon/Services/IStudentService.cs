using Filter_DCSon.Dto;
using Filter_DCSon.Entities;
using Filter_DCSon.Dto;

namespace Filter_DCSon.Services
{
    public interface IStudentService
    {
        void CreateStudent(CreateStudentDto input);
        PageResultStudentDto GetAllWithPageStudent(StudentFilterDto input);
        List<Student> GetAll();
        void Update(int id, UpdateStudentDto input);
        void Delete(int id);
        Student GetById(int id);
    }
}
