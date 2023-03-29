using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Constants;
using WebApplication3.Dtos.Shared;
using WebApplication3.Dtos.Students;
using WebApplication3.Entities;
using WebApplication3.Filters;
using WebApplication3.Services.Interfaces;

namespace WebApplication3.Controllers
{
    //[Authorize]
    //[AuthorizationFilter(UserTypes.Admin)]
    [Route("api/student")]
    [ApiController]
    public class StudentController : ApiControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(
            IStudentService studentService,
            ILogger<StudentController> logger) : base(logger)
        {
            _studentService = studentService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll([FromQuery] FilterDto input)
        {
            try
            {
                var students = _studentService.GetAll(input);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            };
        }

        [HttpPost("create-student")]
        public IActionResult CreateStudent([FromBody] CreateStudentDto input)
        {
            try
            {
                _studentService.Create(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpGet("get-student-by-id/{id}")]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
                Student student = _studentService.GetbyId(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateById([FromBody] UpdateStudentDto input)
        {
            try
            {
                _studentService.Update(input);
                return Ok(_studentService);
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
                _studentService.Delete(id);
                return Ok(_studentService);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpPatch("update-point")]
        public IActionResult UpdatePoint([FromBody] UpdatePointDto input)
        {
            try
            {
                _studentService.UpdatePoint(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpGet("get-list-point/{studentId}")]
        public IActionResult GetListPoint(int studentId)
        {
            try
            {
                var SubjectPoints = _studentService.GetListPointOfStudent(studentId);
                return Ok(SubjectPoints);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpPatch("add-subject")]
        public IActionResult AddSubjectForStudent(int subjectId,int studentId)
        {
            try
            {
                _studentService.AddSubjectForStudent(subjectId,studentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpDelete("delete-subject")]
        public IActionResult DeleteSubject(int subjectId, int studentId)
        {
            try
            {
                _studentService.DeleteSubject(subjectId,studentId);
                return Ok(_studentService);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

    }
}
