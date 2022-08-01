using System;
using System.Linq;
using MentorsWebService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MentorsWebService.Infrastructure
{
    public static class SeedDb
    {
        public static void Initialize(DbContextMentors context)
        {
            var Teacher = new Teacher { UserName = "FirstTeacher" };
            context.Database.EnsureCreated();

            if (!context.Clients.Any())
            {
                context.Clients.Add(new Client { UserName = "c1"});
                context.SaveChanges();
            }
            if (!context.Teachers.Any())
            {
                context.Teachers.Add(Teacher);
                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole("Teacher"));
                context.Roles.Add(new IdentityRole("Client"));
                context.SaveChanges();
            }
            if (!context.Majors.Any())
            {
                context.Majors.Add(new Major { Title = "Разработка ПО", Teacher = Teacher, Description = "Some desc..."});
                context.SaveChanges();
            }
        }

        public static void Init(IServiceCollection services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var dbContextMentors = serviceProvider.GetRequiredService<DbContextMentors>();
            SeedDb.Initialize(dbContextMentors);
        }
    }
}