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
        private readonly IStudentService _studentService; //readonly tức là chỉ được gán một lần trong hàm khởi tạo

        /// <summary>
        /// Inject
        /// </summary>
        /// <param name="studentService"></param>
        /// <param name="logger"></param>
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
        public ActionResult Update(UpdateStudentDto input) //Action Result là một class đại diện cho các response trả về cho client
        {
            try
            {
                _studentService.Update(input);
                //http status code 200
                return Ok();
            }
            //catch (UserFriendlyException ex)
            //{
            //    //logic xử lý ngoại lệ
            //    // trả về http status code là 400
            //    return BadRequest(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    //logic xử lý ngoại lệ
            //    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            //}
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
