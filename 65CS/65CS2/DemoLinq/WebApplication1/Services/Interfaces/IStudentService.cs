using WebApplication1.Dto.Student;

namespace WebApplication1.Services.Interfaces
{
    public interface IStudentService
    {
        void Create(CreateStudentDto input);
        List<StudentDto> GetAll();
        void Update(UpdateStudentDto input);
    }
}
