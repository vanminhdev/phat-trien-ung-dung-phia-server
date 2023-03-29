using Microsoft.AspNetCore.Mvc;
using WebApplication3.Dto.Exceptions;
using WebApplication3.Exceptions;

namespace WebApplication3.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected ILogger _logger;

        public ApiControllerBase(ILogger logger)
        {
            _logger = logger;
        }

        protected IActionResult ReturnException(Exception ex)
        {
            if (ex is UserFriendlyException) //exception có phải là UserFriendlyException
            {
                var userEx = ex as UserFriendlyException; //ép kiểu sang
                return StatusCode(StatusCodes.Status400BadRequest, new ExceptionBody
                {
                    Message = userEx.Message
                });
            }
            _logger.LogError(ex, ex.Message); //log lại lỗi
            return StatusCode(StatusCodes.Status500InternalServerError, new ExceptionBody
            {
                Message = ex.Message
            });
        }
    }
}
