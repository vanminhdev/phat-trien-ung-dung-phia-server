using De5.Dtos.Common;
using De5.Dtos.Employee;

namespace De5.Services.Interfaces
{
    public interface IEmployeeService
    {
        PageResultDto<EmployeeDto> GetAll(EmployeeFilterDto input);
        void CreateEmpolyee(CreateEmployeeDto input);
        void UpdateEmpolyee(UpdateEmployeeDto input);
    }
}
