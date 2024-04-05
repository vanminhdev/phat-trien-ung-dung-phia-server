using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/value123")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("get-by-id")]
        public long Get(long id)
        {
            return id;
        }

        [HttpGet("get-by-name")]
        public string? Get(string? name)
        {
            return $"Hello {name?.Trim()}";
        }

        [HttpGet("get-by-id-2/{id:min(1)}/update/{name}")]
        public int Get2(int id, string name)
        {
            return id;
        }
    }
}
