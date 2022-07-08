using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MentorsWebService.Models
{
    public class Major
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        public byte[] Image { get; set; }
        
        [Required]
        public string Description { get; set; }

        public ICollection<Client> Clients { get; set; } = new List<Client>();

        public ICollection<Module> Modules { get; set; } = new List<Module>();
        
        public Teacher Teacher { get; set; } 
    }
}