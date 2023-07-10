using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace FilterApp
{
    public class MySampleAsyncActionFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _name;

        public MySampleAsyncActionFilterAttribute(string name)
        {
            _name = name;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            System.Console.WriteLine($"Before async execution {_name}");
            await next();
            System.Console.WriteLine($"After async execution {_name}");
        }
    }
}
