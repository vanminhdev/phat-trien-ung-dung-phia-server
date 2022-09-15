using Filter_DCSon.Dto;
using Filter_DCSon.Entities;

namespace Filter_DCSon.Services
{
    public interface IStudentSubjectService
    {
        List<Student> GetStudentBySubject(int subjectId);
        void RemoveStudentBySubject(int studentId, int subjectId);
        void AddScoreWithSubject(int studentId, int subjectId, float score);
        List<GetScoreOfStudentDto> GetScoreOfStudent(int id);
    }
}
