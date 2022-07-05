using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MentorsWebService.Models
{
    public class Client : IdentityUser
    {
        
        public ICollection<Major> Majors { get; set; } = new List<Major>();

        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
        
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}