using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterApp
{
    public class MySampleActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            System.Console.WriteLine("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            System.Console.WriteLine("OnActionExecuting");
        }
    }
}
