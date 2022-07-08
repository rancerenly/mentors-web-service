using System.ComponentModel.DataAnnotations;

namespace MentorsWebService.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        
        [Required]
        public Client Client { get; set; }
        
        public Major Major { get; set; }
    }
}