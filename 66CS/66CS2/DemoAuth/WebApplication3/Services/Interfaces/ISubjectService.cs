using WebApplication.Dtos.Shared;
using WebApplication.Dtos.Subjects;
using WebApplication.Entities;

namespace WebApplication.Services.Interfaces
{
    public interface ISubjectService
    {
        void Create(CreateSubjectDto input);
        void Delete(int id);
        PageResultDto<List<SubjectWithPointDto>> GetAll(FilterDto input);
        Subject GetbyId(int id);
        void Update(UpdateSubjectDto input);
    }
}
