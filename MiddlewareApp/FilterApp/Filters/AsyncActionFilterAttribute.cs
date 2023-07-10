using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace FilterApp.Filters
{
    public class AsyncActionFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _name;

        public AsyncActionFilterAttribute(string name)
        {
            _name = name;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Action filter - Before async - {_name}");
            await next();
            Console.WriteLine($"Action filter - After async - {_name}");
        }
    }
}
