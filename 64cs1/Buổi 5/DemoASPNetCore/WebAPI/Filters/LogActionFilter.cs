using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters
{
    public class LogActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var logger = filterContext.HttpContext.RequestServices.GetService(typeof(ILogger<LogActionFilter>)) as ILogger<LogActionFilter>;
            
            var query = filterContext.HttpContext.Request.Query;

            var idValue = query.FirstOrDefault(q => q.Key == "id");
            string idStr = idValue.Value.FirstOrDefault();
            if (idStr != null)
            {
                int id = int.Parse(idStr);
                //xử lý ở đây
                //filterContext.Result = new BadRequestObjectResult(new { message = "" });
            }

            Log("OnActionExecuting", filterContext.RouteData);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"]; 
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
        }
    }

}
