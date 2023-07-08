using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MiddlewareApp
{
    public class ConsoleLoggerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("ConsoleLoggerMiddleware Before");
            await next(context);
            Console.WriteLine("ConsoleLoggerMiddleware After");
        }
    }
}
