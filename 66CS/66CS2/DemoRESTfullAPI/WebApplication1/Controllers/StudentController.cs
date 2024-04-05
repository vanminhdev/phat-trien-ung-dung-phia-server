using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Entity;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();

        [HttpPost("create")]
        public IActionResult CreateStudent(CreateStudentDto input) //tại sao request body lại binding vào hàm này được ?
        {
            if (string.IsNullOrEmpty(input.Name))
            {
                return BadRequest("Tên không hợp lệ"); //http status 400
            }

            _students.Add(new Student
            {
                Name = input.Name,
            });
            //các hàm đều trả về các đối tượng implement interface IActionResult
            return Ok(); //http status code 200
        }

        [HttpGet("get-all")]
        public IActionResult GetStudents()
        {
            //sử dụng hàm select (linq)
            var result = _students.Select(s => new StudentDto
            {
                Name = s.Name,
            });
            return Ok(result);
        }

        [HttpGet("get-by-id/{id}")]
        public StudentDto GetById(int id)
        {
            //sử dụng hàm firstOrDefault
            return null;
        }
    }
}
