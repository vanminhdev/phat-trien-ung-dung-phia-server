using WebApplication1.Dto.Student;

namespace WebApplication1.Services.Interfaces
{
    public abstract class StudentAbsService
    {
        protected int A;

        protected StudentAbsService()
        {
            A = 0;
        }

        public abstract void Create(CreateStudentDto input);
        public abstract List<StudentDto> GetAll();
        public abstract void Update(UpdateStudentDto input);
    }
}
