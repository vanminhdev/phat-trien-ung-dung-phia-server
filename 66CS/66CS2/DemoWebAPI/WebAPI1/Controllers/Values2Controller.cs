using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Values2Controller : ControllerBase
    {
        [HttpGet]
        public void Get() 
        {
        }

        //trùng http method
        //[HttpGet]
        //public void Get2()
        //{
        //}

        [HttpPost]
        public void Post()
        {
        }
    }
}
