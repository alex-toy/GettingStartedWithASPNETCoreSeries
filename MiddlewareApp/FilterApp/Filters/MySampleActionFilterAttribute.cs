using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FilterApp.Filters
{
    public class MySampleActionFilterAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        private readonly string _name;
        public int Order { get; set; }

        public MySampleActionFilterAttribute(string name, int order = 0)
        {
            _name = name;
            Order = order;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"OnActionExecuted {_name} - order : {Order}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"OnActionExecuting {_name} - order : {Order}");
        }
    }
}
