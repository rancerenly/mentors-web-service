using System;
using System.Linq;

namespace MentorsWebService.Models
{
    public interface IRepository
    {
        IQueryable<Teacher> GetTeachers { get; }
        IQueryable<Client> GetClients { get; }

        Client GetClient(string Id);
        Teacher GetTeacher(string Id);
    }
}