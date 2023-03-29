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
    public class StudentSubjectController : ApiControllerBase
    {
        private readonly IStudentSubjectService _studentSubjectService;
        private readonly ILogger _logger;

        public StudentSubjectController(IStudentSubjectService studentSubjectService,
            ILogger<StudentSubjectController> logger)
        {
            _studentSubjectService = studentSubjectService;
            _logger = logger;
        }

        [HttpPost("Add-score-with-subject")]
        public IActionResult AddScoreWithSubject(int studentId, int subjectId, float score)
        {
            try
            {
                _studentSubjectService.AddScoreWithSubject(studentId, subjectId, score);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpGet("get-student-by-subject")]
        public ActionResult GetStudentBySubject(int subjectId)
        {
            try
            {
                var studentInClass = _studentSubjectService.GetStudentBySubject(subjectId);
                return Ok(studentInClass);
            }
            catch
            {
                _logger.LogInformation("Không thể thêm được....");
                return BadRequest();
            }
        }

        [HttpDelete("remove-student-by-idclass")]
        public IActionResult RemoveStudentBySubject(int studentId, int subjectId)
        {
            try
            {
                _studentSubjectService.RemoveStudentBySubject(studentId, subjectId);
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

        [HttpGet("get-score-of-student")]
        public IActionResult GetScoreOfStudent(int studentId)
        {
            try
            {
                var results = _studentSubjectService.GetScoreOfStudent(studentId);
                return Ok(results);
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
