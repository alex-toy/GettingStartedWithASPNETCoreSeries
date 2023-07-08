using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationApp
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
            services.AddControllers();
            services.Configure<MyApiOptions>(Configuration.GetSection("myAPI"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                Console.WriteLine("## Configuration ###################################");
                Console.WriteLine($"myKey : {Configuration["myKey"]}");
                Console.WriteLine($"Url : {Configuration["myAPI:url"]}");
                Console.WriteLine($"apiKey : {Configuration["myAPI:apiKey"]}");

                Console.WriteLine($"nonExistingKey : {Configuration.GetValue<int>("nonExistingKey", 1234)}");
                Console.WriteLine($"url test : {Configuration.GetValue<string>("myAPI:url", "url test")}");
                next();
            });

            app.Use(async (context, next) =>
            {
                Console.WriteLine("## Configuration class ###################################");
                var apiOptions = new MyApiOptions();
                Configuration.GetSection("myAPI").Bind(apiOptions);
                Console.WriteLine($"Url : {apiOptions.Url}");
                Console.WriteLine($"ApiKey : {apiOptions.ApiKey}");
                next();
            });

            app.Use(async (context, next) =>
            {
                Console.WriteLine("## Configuration class bis ###################################");
                var apiOptions = Configuration.GetSection("myAPI").Get<MyApiOptions>();
                Console.WriteLine($"Url : {apiOptions.Url}");
                Console.WriteLine($"ApiKey : {apiOptions.ApiKey}");
                next();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //string myKey = Configuration["myKey"];
            //Console.WriteLine($"myKey : {myKey}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
