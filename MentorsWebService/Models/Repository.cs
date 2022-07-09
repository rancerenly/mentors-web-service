using System;
using System.Linq;

namespace MentorsWebService.Models
{
    public class Repository : IRepository
    {
        private DbContextMentors DbContext;
        public Repository(DbContextMentors dbcontext)
        {
            DbContext = dbcontext;
        }

        public IQueryable<Teacher> GetTeachers => DbContext.Teachers;
        
        public IQueryable<Client> GetClients => DbContext.Clients;

        public Client GetClient(string Id)
        {
            return DbContext.Clients.FirstOrDefault(o => o.Id == Id);
        }

        public Teacher GetTeacher(string Id)
        {
            return DbContext.Teachers.FirstOrDefault(o => o.Id == Id);
        }
    }
}