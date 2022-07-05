using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MentorsWebService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc(options => options.EnableEndpointRouting = false);
            
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
            }
            
            app.UseStaticFiles();

            app.UseMvc(option =>
            {
                option.MapRoute(
                    null, 
                    "{Category}/{Page:int}",
                    new { controller = "Admin", action = "Add" }
                    );
                
                option.MapRoute(
                    null,
                    "{controller=Home}/{action=Index}/{id?}" 
                    );
            });

            
        }
    }
}