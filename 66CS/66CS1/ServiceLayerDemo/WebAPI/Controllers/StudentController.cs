using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DbContexts;
using WebAPI.Dtos.Students;
using WebAPI.Exceptions;
using WebAPI.Services.Abstract;
using WebAPI.Services.Implements;

namespace WebAPI.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ApplicationDbContext _context;

        public StudentController(IStudentService studentService, ApplicationDbContext dbContext)
        {
            _studentService = studentService;
            _context = dbContext;
            //_studentService = new StudentService();
        }

        [HttpPost("add")]
        public IActionResult CreateStudent(CreateStudentDto input)
        {
            return Ok(_studentService.CreateStudent(input));
        }

        [HttpPut("update")]
        public IActionResult UpdateStudent(UpdateStudentDto input)
        {
            try
            {
                _studentService.UpdateStudent(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
