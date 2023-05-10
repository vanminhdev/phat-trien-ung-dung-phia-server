using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Dto.Student;
using WebApplication1.Filters;
using WebApplication1.Services.Implements;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("create")]
        public IActionResult Create(CreateStudentDto input)
        {
            _studentService.Create(input);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateStudentDto input)
        {
            _studentService.Update(input);
            return Ok();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById([Range(1, int.MaxValue, ErrorMessage = "Id phải lớn hơn 0")] int id)
        {
            return Ok();
        }
    }
}
