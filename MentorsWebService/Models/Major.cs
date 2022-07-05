using System.Collections.Generic;

namespace MentorsWebService.Models
{
    public class Major
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public byte[] Image { get; set; }
        
        public string Description { get; set; }

        public ICollection<Client> Clients { get; set; } = new List<Client>();
        
        public ICollection<Teacher>  Teachers { get; set; } = new List<Teacher>();
    }
}