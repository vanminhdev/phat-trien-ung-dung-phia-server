using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto.Values;

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

        // GET api/values/5
        [HttpGet("get-by-id/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("get-by-id-2/{id}")]
        public string Get2(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post(CreateValueDto input)
        {
            input.Name = input.Name.Trim();
            return input.Name;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
