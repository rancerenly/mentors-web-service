using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MentorsWebService.Models
{
    public class Repository : IRepository
    {
        private readonly DbContextMentors _dbContext;
        public Repository(DbContextMentors dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Teacher> GetTeachers => _dbContext.Teachers;
        public IQueryable<Client> GetClients => _dbContext.Clients;
        public IQueryable<Major> GetMajors => _dbContext.Majors.Include(t => t.Teacher);
        public IdentityUser GetUser(string id) => _dbContext.Users.FirstOrDefault(o => o.Id == id);

        public Client GetClient(string id) => _dbContext.Clients.FirstOrDefault(o => o.Id == id);

        public Teacher GetTeacher(string id) => _dbContext.Teachers.FirstOrDefault(o => o.Id == id);
        public Major GetMajor(int id) => _dbContext.Majors.FirstOrDefault(m => m.Id == id);
        
        public void AddTeacher(Teacher teacher)
        {
            var isExist = _dbContext.Teachers.Any(t => t.Id == null);
            
            if (!isExist)
            {
                _dbContext.Teachers.Add(teacher);
            }
            
            _dbContext.SaveChanges();
        }
    }
}