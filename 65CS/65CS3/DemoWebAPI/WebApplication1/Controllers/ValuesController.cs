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
        [HttpGet("get-by-id/{id}")]
        public string Get(int id, string name, int age)
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
        public CreateValueDto Post(CreateValueDto input)
        {
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
