using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Filter_DCSon.Dto;
using Filter_DCSon.Services;
using Filter_DCSon.DbContexts;

namespace Filter_DCSon.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ApiControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly ILogger _logger;

        public SubjectController(ISubjectService subjectService, ILogger<SubjectController> logger)
        {
            _subjectService = subjectService;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                var results = _subjectService.GetAll();
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

        [HttpGet("get-all-with-page")]
        public IActionResult GetAllWithPageClassroom([FromQuery] SubjectFilterDto input)
        {
            try
            {
                var results = _subjectService.GetAllWithPageSubject(input);
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

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _subjectService.GetById(id);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        public ActionResult CreateSubject([FromForm] CreateSubjectDto input)
        {
            try
            {
                _subjectService.CreateSubject(input);
                return Ok();
            }
            catch
            {
                _logger.LogInformation("Không thể thêm được....");
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public IActionResult Update(int id, [FromForm] UpdateSubjectDto input)
        {
            try
            {
                _subjectService.Update(id, input);
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
                _subjectService.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
