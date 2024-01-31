using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Exceptions;

namespace WebApplication1.Filters
{
    public class SampleExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ngoại lệ có kiểm soát
            if (context.Exception is UserFriendlyException)
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.Message,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            else //các ngoại lệ khác
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
