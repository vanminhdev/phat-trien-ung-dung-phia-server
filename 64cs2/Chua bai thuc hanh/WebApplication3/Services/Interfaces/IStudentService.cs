using WebApplication3.Dto.Shared;
using WebApplication3.Dto.Students;
using WebApplication3.Entities;

namespace WebApplication3.Services.Interfaces
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
