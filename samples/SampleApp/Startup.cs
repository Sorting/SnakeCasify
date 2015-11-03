using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Mvc.Formatters;
using Newtonsoft.Json;
using Sorting.SnakeCase.Json.Serialization;
using Sorting.SnakeCase.Mvc;

namespace SampleApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc((options) =>
            {
                // Add the snake case query value provider factory to enable snake cased query argument names to be mapped to camel cased C# parameter names.
                options.ValueProviderFactories.Add(new SnakeCaseQueryValueProviderFactory());

                // Add json input and output formatters to enable serialization and deserialization of snake cased bodies.
                options.InputFormatters.Add(
                    new JsonInputFormatter(
                        new JsonSerializerSettings
                        {
                            ContractResolver = new SnakeCasePropertyNamesContractResolver()
                        }));

                options.OutputFormatters.Add(
                    new JsonOutputFormatter(
                        new JsonSerializerSettings
                        {
                            ContractResolver = new SnakeCasePropertyNamesContractResolver()
                        }));

            });
            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();

            
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();            

            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();

            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc();                ;
            // Add the following route for porting Web API 2 controllers.
            // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
        }
    }
}
