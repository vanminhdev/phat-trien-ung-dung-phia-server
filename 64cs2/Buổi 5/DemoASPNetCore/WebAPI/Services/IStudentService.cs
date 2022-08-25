using WebAPI.Dtos;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IStudentService
    {
        void Create(CreateStudentDto input);
        PageResultDto<List<Student>> GetAll(StudentFilterDto input);
    }
}
