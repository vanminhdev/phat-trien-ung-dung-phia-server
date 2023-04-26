using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet]
        [Route("get-by-id")]
        public string Get(int id, string name)
        {
            return "value";
        }

        [HttpGet("get-by-id2/{id}")]
        public string Get2(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost("create")]
        public void Post([FromBody] string value)
        {
        }

        [HttpPost("create2")]
        public CreateValueDto Post2(CreateValueDto input)
        {
            //xử lý
            return input;
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
