using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmployeeManagement.Models;
namespace EmployeeManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option=>option.EnableEndpointRouting=false);
            services.AddSingleton<IEmployeeRepository,MockEmployeeRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //customizing UseDefault files
            /*DefaultFilesOptions defaultFilesOptions= new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("foo.html");
            app.UseDefaultFiles(defaultFilesOptions); //uses the default.html*/
            app.UseStaticFiles(); //loads static files from wwwroot
            //app.UseMvcWithDefaultRoute();
            //app.UseMvc(); //Using Attribute Routing
            app.UseMvc(routes =>
                {
                    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });


            //using file server middleware instead of the above
            //FileServerOptions fileServerOptions= new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            //app.UseFileServer(fileServerOptions);
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
