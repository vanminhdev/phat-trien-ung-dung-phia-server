using WebAPI.Dtos.Students;
using WebAPI.Entities;

namespace WebAPI.Services.Abstract
{
    public interface IStudentService
    {
        Student CreateStudent(CreateStudentDto input);

        void UpdateStudent(UpdateStudentDto student);
    }
}
