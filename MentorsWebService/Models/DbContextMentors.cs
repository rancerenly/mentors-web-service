using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MentorsWebService.Models
{
    public class DbContextMentors: IdentityDbContext<IdentityUser>
    {
        public DbContextMentors(DbContextOptions<DbContextMentors> contextOptions) : base(contextOptions)
        {
            
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}