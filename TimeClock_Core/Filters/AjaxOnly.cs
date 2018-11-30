namespace TimeClock_Core.Filters
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using TimeClock_Core.Extensions;

    public class AjaxOnly : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new ObjectResult(filterContext.ModelState)
                {
                    Value = $"The server throw an exception of type { StatusCodes.Status400BadRequest }; Please use an XMLHttpRequest",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
