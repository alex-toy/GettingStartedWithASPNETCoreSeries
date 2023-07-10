using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FilterApp.Filters
{
    public class ActionFilterAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        private readonly string _name;
        public int Order { get; set; }

        public ActionFilterAttribute(string name, int order = 0)
        {
            _name = name;
            Order = order;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Action filter after {_name} - order : {Order}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Action filter during {_name} - order : {Order}");
        }
    }
}
