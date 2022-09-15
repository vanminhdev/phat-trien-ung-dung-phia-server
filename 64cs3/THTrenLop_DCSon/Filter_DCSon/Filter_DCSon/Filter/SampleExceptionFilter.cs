using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter_DCSon.Filter
{
    public class SampleExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult
            {
                Content = context.Exception.Message,
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
