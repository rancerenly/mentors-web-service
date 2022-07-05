using Microsoft.AspNetCore.Identity;

namespace MentorsWebService.Models
{
    public class Teacher : IdentityUser
    { 
        public int MajorId { get; set; } 
        public Major Major { get; set; }
        public string Certificate { get; set; }
        public string Bio { get; set; }
       
    }
}