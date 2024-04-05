using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI1.Dto;
using WebAPI1.Model;

namespace WebAPI1.Controllers
{
    [Route("api/value")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("get-strings")]
        public string[] GetStrings()
        {
            return new string[] { "value1" };
        }

        [HttpGet("sum")]
        public int Sum(int a, long b)
        {
            int result = HandleSum(a, (int)b);
            return result;
        }

        [HttpGet("hello")]
        public string Hello([FromQuery] string? name)
        {
            return $"Xin chào {name?.Trim()}";
        }

        [Route("get-by-id/{id:min(1)}")]
        [HttpGet]
        public void GetById(int id)
        {
            return;
        }

        [HttpGet("get-by-id2/{id}/abc/{name}")]
        public void GetById2(int id, string name)
        {
            return;
        }

        [HttpPut("product/{id}/update")]
        public void Update(int id)
        {
            return;
        }

        [HttpPost("product/add")]
        public IActionResult CreateProduct([FromForm] CreateProductDto input)
        {
            if (string.IsNullOrEmpty(input.Name))
            {
                return BadRequest(new ApiResponse
                {
                    Message = "Tên không hợp lệ"
                });
            }
            return Ok();
        }

        [HttpPost("product/update/{id}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] CreateProductDto input)
        {
            if (string.IsNullOrEmpty(input.Name))
            {
                return BadRequest(new ApiResponse
                {
                    Message = "Tên không hợp lệ"
                });
            }
            return Ok();
        }

        private int HandleSum(int a, int b)
        {
            return a + b;
        }
    }
}
