using Filter_DCSon.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Filter_DCSon.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult ReturnException(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ExceptionBody
            {
                Message = ex.Message
            });
        }
    }
}
