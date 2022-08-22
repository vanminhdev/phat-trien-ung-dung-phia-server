using WebAPI.Dtos;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IStudentService
    {
        void Create(CreateStudentDto input);
        List<Student> GetAll();
    }
}
