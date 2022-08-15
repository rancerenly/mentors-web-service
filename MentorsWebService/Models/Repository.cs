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
        public Module GetModule(int id) => _dbContext.Modules.FirstOrDefault(m => m.Id == id);

        public Exercise GetExercise(int id) => _dbContext.Exercises.FirstOrDefault(m => m.Id == id);

        /*public void AddTeacher(Teacher teacher)
        {
            var isExist = _dbContext.Teachers.Any(t => t.Id == null);

            if (!isExist)
            {
                _dbContext.Teachers.Add(teacher);
            }

            _dbContext.SaveChanges();
        }*/

        public void AddModule(Module module)
        {
            _dbContext.Modules.Add(module);
            _dbContext.SaveChanges();
        }

        public void AddExercise(Exercise exercise)
        {
            _dbContext.Exercises.Add(exercise);
            _dbContext.SaveChanges();
        }

        public void AddMajor(Major major)
        {
            Major newMajor = _dbContext.Majors.FirstOrDefault(o => o.Id == major.Id);
            if (newMajor == null)
            {
                _dbContext.Majors.Add(major);
            }
            _dbContext.SaveChanges();
        }
    }
}