using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Dtos
{
    public class StudentFilterDto
    {
        [FromQuery(Name = "studentCode")]
        public string StudentCode { get; set; }

        [FromQuery(Name = "studentName")]
        public string StudentName { get; set; }
    }
}
