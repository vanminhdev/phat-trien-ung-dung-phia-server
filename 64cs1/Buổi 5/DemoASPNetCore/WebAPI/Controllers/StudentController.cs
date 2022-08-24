using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("get-all")]
        //public IActionResult GetAll(int pageSize, int pageIndex, string keyword)
        public IActionResult GetAll([FromQuery] StudentFilterDto input)
        {
            return Ok(_studentService.GetAllStudent(input));
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            //_studentService.
            return Ok();
        }

        [HttpPost]
        //public IActionResult CreateStudent(CreateStudentDto input)
        //public IActionResult CreateStudent([FromBody] CreateStudentDto input) //giống nhau
        public IActionResult CreateStudent([FromForm] CreateStudentDto input) //dùng trong trường hợp lấy file.
        {
            try
            {
                _studentService.CreateStudent(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ExceptionBody 
                { 
                    Message = ex.Message
                });
            }
        }
    }
}
