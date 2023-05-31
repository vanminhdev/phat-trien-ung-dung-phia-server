using De5.DbContexts;
using De5.Dtos.Common;
using De5.Dtos.Employee;
using De5.Entities;
using De5.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace De5.Services.Implements
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateEmpolyee(CreateEmployeeDto input)
        {
            if (_dbContext.Employees.Any(e => e.Code == input.Code))
            {
                throw new Exception("Mã nhân viên bị trùng");
            }

            _dbContext.Employees.Add(new Employee
            {
                Code = input.Code,
                Name = input.Name,
                Address = input.Address,
                Age = input.Age,
                CreatedDate = DateTime.Now, //lấy ngày giờ hiện tại
            });
            _dbContext.SaveChanges();
        }

        public PageResultDto<EmployeeDto> GetAll(EmployeeFilterDto input)
        {
            var result = new PageResultDto<EmployeeDto>();
            var query = _dbContext.Employees
                .Where(e => e.Name != null && e.Name.Contains(input.Keyword));

            result.TotalItem = query.Count();
            query = query.Skip(input.Skip())
                .Take(input.PageSize);

            result.Items = query.Select(x => new EmployeeDto
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Adress = x.Address,
                Age = x.Age,
            }).ToList();
            return result;
        }

        public void UpdateEmpolyee(UpdateEmployeeDto input)
        {
            if (_dbContext.Employees.Where(e => e.Code == input.Code && e.Id != input.Id).Any()) //bỏ qua chính nhân viên hiện tại theo id truyền vào
            {
                throw new Exception("Mã nhân viên bị trùng");
            }

            var employee = _dbContext.Employees.FirstOrDefault(o => o.Id == input.Id);
            if (employee == null)
            {
                throw new Exception("Không tìm thấy nhân viên");
            }
            employee.Code = input.Code;
            employee.Name = input.Name;
            employee.Age = input.Age;
            employee.Address = input.Address;
            _dbContext.SaveChanges();
        }
    }
}
