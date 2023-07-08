using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;

namespace MiddlewareApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddTransient<ConsoleLoggerMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                Console.WriteLine("Use Before");
                await next();
                Console.WriteLine("Use After");
            });

            app.UseMiddleware<ConsoleLoggerMiddleware>();

            app.Map("/map", MapHandler);

            //app.MapWhen(context => context.Request.Query.ContainsKey("q"), HandleRequestWithQuery);
            app.UseWhen(context => context.Request.Query.ContainsKey("q"), HandleRequestWithQuery);

            app.Run(async context =>
            {
                Console.WriteLine("Run Hello world");
                string message = "Hello world";
                byte[] data = Encoding.UTF8.GetBytes(message);
                await context.Response.Body.WriteAsync(data);
            });
        }

        private void HandleRequestWithQuery(IApplicationBuilder app)
        {
            app.Run(async context => Console.WriteLine("Contains query") );
        }

        private async void MapHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                Console.WriteLine("MapHandler");
                string message = "Hello from Map method";
                byte[] data = Encoding.UTF8.GetBytes(message);
                await context.Response.Body.WriteAsync(data);
            });
        }
    }
}
