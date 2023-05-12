using WebApplication1.Dto.Student;
using WebApplication1.Entities;

namespace WebApplication1.Services.Interfaces
{
    public interface IClassroomService
    {
        List<StudentDto> GetAllStudent(int classroomId);
    }
}
