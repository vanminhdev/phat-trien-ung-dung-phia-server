using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto.Exceptions;
using WebApplication1.Exceptions;

namespace WebApplication1.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected ILogger _logger;

        public ApiControllerBase(ILogger logger)
        {
            _logger = logger;
        }

        protected ActionResult HandleException(Exception ex)
        {
            //kiểm tra xem đối tượng trả ra có phải là một thể hiện của class UserFriendlyException
            if (ex is UserFriendlyException)
            {
                // trả về http status code là 400
                return BadRequest(new ResponseError() { Message = ex.Message, });
            }
            //những lỗi khác thì sẽ được log lại
            _logger.LogError(ex, ex.Message);
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new ResponseError() { Message = ex.Message, }
            );
        }
    }
}
