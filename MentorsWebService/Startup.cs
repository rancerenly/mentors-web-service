using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorsWebService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MentorsWebService.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace MentorsWebService
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration config)
        {
            _configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();
            
            services.AddMvc(options => options.EnableEndpointRouting = false);
            
            services.AddDbContext<DbContextMentors>(options => options.UseSqlServer(_configuration["MentorsSchool:ConnectionStrings"]));
            
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DbContextMentors>()
                .AddDefaultTokenProviders();
            
            SeedDb.Init(services);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
            }
            
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
            
        }
    }
}