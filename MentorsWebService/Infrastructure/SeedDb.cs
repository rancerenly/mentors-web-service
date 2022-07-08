using System;
using System.Linq;
using MentorsWebService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MentorsWebService.Infrastructure
{
    public static class SeedDb
    {
        public static void Initialize(DbContextMentors context)
        {
            context.Database.EnsureCreated();

            if (!context.Clients.Any())
            {
                context.Clients.Add(new Client { UserName = "c1"});
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