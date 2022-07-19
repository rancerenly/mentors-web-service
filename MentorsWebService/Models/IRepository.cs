using System;
using System.Linq;

namespace MentorsWebService.Models
{
    public interface IRepository
    {
        IQueryable<Teacher> GetTeachers { get; }
        IQueryable<Client> GetClients { get; }
        IQueryable<Major> GetMajors { get; }

        Client GetClient(string id);
        Teacher GetTeacher(string id);
        Major GetMajor(int id);

        void AddTeacher(Teacher teacher);
    }
}