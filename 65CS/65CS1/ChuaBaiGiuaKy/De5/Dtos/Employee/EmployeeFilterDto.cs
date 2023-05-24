using De5.Dtos.Common;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace De5.Dtos.Employee
{
    public class EmployeeFilterDto : FilterDto
    {
        [FromQuery(Name = "startAge")]
        public int? StartAge { get; set; }

        [FromQuery(Name = "endAge")]
        public int? EndAge { get; set; }
    }
}
