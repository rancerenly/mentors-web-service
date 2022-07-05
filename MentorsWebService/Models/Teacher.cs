
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MentorsWebService.Models
{
    public class Teacher : IdentityUser
    { 
        
        public string Certificate { get; set; }
        public string Bio { get; set; }
        public ICollection<Major> Majors { get; set; } = new List<Major>();
    }
}