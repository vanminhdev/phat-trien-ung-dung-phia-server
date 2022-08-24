using WebAPI.Dto;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IStudentService
    {
        void CreateStudent(CreateStudentDto input);
        PageResultStudentDto GetAllStudent(StudentFilterDto input);
    }
}
