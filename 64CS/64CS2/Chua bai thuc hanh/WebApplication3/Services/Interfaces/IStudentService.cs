using WebApplication.Dtos.Shared;
using WebApplication.Dtos.Students;
using WebApplication.Entities;

namespace WebApplication.Services.Interfaces
{
    public interface IStudentService
    {
        void AddSubjectForStudent(int subjectId, int studentId);
        void Create(CreateStudentDto input);
        void Delete(int id);
        void DeleteSubject(int subjectId, int studentId);
        PageResultDto<List<Student>> GetAll(FilterDto input);
        Student GetbyId(int id);
        List<StudentSubjectDto> GetListPointOfStudent(int studentId);
        void Update(UpdateStudentDto input);
        void UpdatePoint(UpdatePointDto input);
    }
}
