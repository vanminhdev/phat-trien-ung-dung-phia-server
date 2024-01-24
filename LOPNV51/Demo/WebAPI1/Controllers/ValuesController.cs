using Microsoft.AspNetCore.Mvc;
using WebAPI1.Dtos;
using WebAPI1.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI1.Controllers
{
    [Route("api/value")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();

        [HttpGet("get-by-id/{id:min(1)}")]
        public string GetById(int id, string name)
        {
            return "";
        }

        [HttpGet("get-by-name")]
        public string GetByName(string name)
        {
            return "";
        }

        [HttpGet("find-student-2")]
        public void FindStudent2(string studentCode, string studentName)
        {
            //xử lý tìm kiếm sinh viên
        }

        [HttpGet("find-student")]
        public void FindStudent([FromQuery] StudentFilterDto input)
        {
            //xử lý tìm kiếm sinh viên
        }

        // GET: api/<ValuesController>
        [HttpGet("abc/def/get1")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("get2")]
        public IEnumerable<string> Get(string param1, string param2)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("add-student")]
        public void CreateStudent([FromForm] CreateStudentDto input)
        {
            //xử lý thêm sinh viên
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
