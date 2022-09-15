using Filter_DCSon.Dto;
using Filter_DCSon.Entities;

namespace Filter_DCSon.Services
{
    public interface ISubjectService
    {
        List<Subject> GetAll();
        PageResultSubjectDto GetAllWithPageSubject(SubjectFilterDto input);
        void CreateSubject(CreateSubjectDto input);
        void Update(int id, UpdateSubjectDto input);
        void Delete(int id);
        Subject GetById(int id);
    }
}
