using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Dtos.Shared;
using WebApplication.Dtos.Subjects;
using WebApplication.Entities;
using WebApplication.Services.Interfaces;

namespace WebApplication.Controllers
{
    //[Authorize]
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ApiControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(
            ISubjectService subjectService,
            ILogger<SubjectController> logger) : base(logger)
        {
            _subjectService = subjectService;
        }

        /// <summary>
        /// danh sách môn học + 1 trường điểm trung bình nếu môn học đó có điểm của sinh viên,
        /// nếu không có điểm thì trả về 0 hoặc null
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("get-all")]
        public IActionResult GetAll([FromForm] FilterDto input)
        {
            try
            {
                var classrooms = _subjectService.GetAll(input);
                return Ok(classrooms);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpPost("create")]
        public IActionResult CreateSubject([FromForm] CreateSubjectDto input)
        {
            try
            {
                _subjectService.Create(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpGet("get-classroom-by-id/{id}")]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
                Subject subject = _subjectService.GetbyId(id);
                return Ok(subject);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateById([FromBody] UpdateSubjectDto input)
        {
            try
            {
                _subjectService.Update(input);
                return Ok(_subjectService);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                _subjectService.Delete(id);
                return Ok(_subjectService);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        //danh sách những sinh viên có điểm cao nhất theo id môn học
    }
}
