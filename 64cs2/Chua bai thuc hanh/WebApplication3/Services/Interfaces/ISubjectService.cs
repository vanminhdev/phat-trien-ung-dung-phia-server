using WebApplication3.Dto.Shared;
using WebApplication3.Dto.Subjects;
using WebApplication3.Entities;

namespace WebApplication3.Services.Interfaces
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
