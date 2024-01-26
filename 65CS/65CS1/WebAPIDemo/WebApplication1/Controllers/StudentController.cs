using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto.Exceptions;
using WebApplication1.Dto.Student;
using WebApplication1.Exceptions;
using WebApplication1.Services.Implements;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ApiControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService,
            ILogger<StudentController> logger)
            : base(logger)
        {
            _studentService = studentService;
        }

        [HttpPost("create")]
        public void Create(CreateStudentDto input)
        {
            _studentService.Create(input);
        }

        [HttpPut("update")]
        public ActionResult Update(UpdateStudentDto input)
        {
            try
            {
                _studentService.Update(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("get-all")]
        public ActionResult<List<StudentDto>> GetAll()
        {
            try
            {
                return Ok(_studentService.GetAll());
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
