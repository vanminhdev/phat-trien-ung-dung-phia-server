using WebApplication1.Dto.Students;

namespace WebApplication1.Services.Abstract
{
    public interface IStudentService
    {
        StudentDto CreateStudent(CreateStudentDto input);

        void UpdateStudent(UpdateStudentDto input);

        List<StudentDto> GetAll();
    }
}
