using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace RoutingApp
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
            services.AddRouting(options =>
            {
                options.ConstraintMap.Add("myCustom", typeof(MyCustomConstraint));
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                var method = context.Request.Method;
                await next();
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes($"hello world"));
                });

                endpoints.MapGet("/hello/alex", async context =>
                {
                    await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes($"hello alex specific"));
                });

                endpoints.MapGet("/hello/{name:alpha:minlength(2)?}", async context =>
                {
                    string name = context.Request.RouteValues["name"].ToString();
                    await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes($"hello {name}"));
                });

                endpoints.MapGet("/custom/{name:myCustom}", async context =>
                {
                    string name = context.Request.RouteValues["name"].ToString();
                    await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes($"hello {name}"));
                });

                endpoints.MapControllers();
            });
        }
    }
}
