using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace MentorsWebService.Models
{
    public interface IRepository
    {
        IQueryable<Teacher> GetTeachers { get; }
        IQueryable<Client> GetClients { get; }
        IQueryable<Major> GetMajors { get; }

        Client GetClient(string id);
        Teacher GetTeacher(string id);
        IdentityUser GetUser(string id);
        Major GetMajor(int id);

        void AddTeacher(Teacher teacher);
    }
}