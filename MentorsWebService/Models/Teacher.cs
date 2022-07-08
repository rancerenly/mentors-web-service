
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MentorsWebService.Models
{
    public class Teacher : IdentityUser
    {
        public string Certificate { get; set; }
        
        [Required]
        public string Bio { get; set; }
        
        public ICollection<Major> Majors { get; set; } = new List<Major>();
    }
}