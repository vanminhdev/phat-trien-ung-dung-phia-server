using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Exceptions;

namespace WebApplication1.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is UserFriendlyException)
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.Message,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            else
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
