using Microsoft.AspNetCore.Mvc;
using WebAPI1.Dtos;
using WebAPI1.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI1.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static int _id = 0;
        private static List<Student> _students = new List<Student>();

        // GET: api/<ValuesController>
        [HttpGet("get1")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("get2")]
        public IEnumerable<string> Get([FromQuery] string value, string value2, string value3)
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("get-by-id/{id:min(0)}")]
        public ResponseDto GetById([FromRoute] int id, string name)
        {
            return new ResponseDto()
            {
                Name = "a",
                Age = 18
            };
        }

        [HttpGet("get-by-filter")]
        public void Filter([FromQuery] StudentFilterDto input)
        {
            //xử lý bộ lọc
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost("add")]
        public void AddStudent([FromBody] StudentAddDto input)
        {
            //xử lý thêm sinh viên
            _students.Add(new Student
            {
                Id = _id++,
                Name = input.StudentName,
                // các trường khác
            });
        }

        [HttpPost("add-with-avatar")]
        public void AddStudent([FromForm] StudentAddWithAvatarDto input)
        {
            //xử lý thêm sinh viên
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
