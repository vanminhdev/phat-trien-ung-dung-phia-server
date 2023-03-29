using Filter_DCSon.Dto;
using Filter_DCSon.Services;
using Filter_DCSon.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Filter_DCSon.Filters;

namespace Filter_DCSon.Controllers
{
    [SampleExceptionFilter]
    [LogActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ApiControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger _logger;

        public StudentController(IStudentService studentService,
            ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        } 

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _studentService.GetAll();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _studentService.GetById(id);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("get-all-with-page")]
        //public IActionResult GetAll(int pageSize, int pageIndex, string keyword)
        public IActionResult GetAllWithPage([FromQuery] StudentFilterDto input)
        {
            try
            {
                var result = _studentService.GetAllWithPageStudent(input);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        public IActionResult CreateStudent([FromForm] CreateStudentDto input)
        {
            try
            {
                _studentService.CreateStudent(input);
                return Ok();
            }
            catch
            {
                _logger.LogInformation("Không thể thêm được....");
                return BadRequest();
            }
        }


        [HttpPut("update")]
        public IActionResult Update(int id, [FromForm] UpdateStudentDto input)
        {
            try
            {
                _studentService.Update(id, input);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleted/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _studentService.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}