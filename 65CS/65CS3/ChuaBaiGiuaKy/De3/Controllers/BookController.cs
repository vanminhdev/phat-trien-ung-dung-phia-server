using De3.Dtos.Book;
using De3.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace De3.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService) 
        {
            _bookService = bookService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll([FromQuery] BookFilterDto input)
        {
            try
            {
                return Ok(_bookService.GetAll(input));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateBookDto input)
        {
            try
            {
                _bookService.CreateBook(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
