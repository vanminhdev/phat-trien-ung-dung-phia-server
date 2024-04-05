using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("sum")]
        public int Sum(int a, int b)
        {
            return SumHandle(a, b);
        }

        private int SumHandle(int a, int b)
        {
            int result = a + b;
            return result;
        }
    }
}
