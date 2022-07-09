using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MentorsWebService.Models
{
    public class Repository : IRepository
    {
        private DbContextMentors DbContext;
        public Repository(DbContextMentors dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<Teacher> GetTeachers => DbContext.Teachers;
        
        public IQueryable<Client> GetClients => DbContext.Clients;
        public IQueryable<Major> GetMajors => DbContext.Majors.Include(t => t.Teacher);

        public Client GetClient(string id) => DbContext.Clients.FirstOrDefault(o => o.Id == id);

        public Teacher GetTeacher(string id) => DbContext.Teachers.FirstOrDefault(o => o.Id == id);
        public Major GetMajor(int id) => DbContext.Majors.FirstOrDefault(m => m.Id == id);
    }
}