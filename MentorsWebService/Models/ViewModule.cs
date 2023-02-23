using System.ComponentModel.DataAnnotations;

namespace MentorsWebService.Models
{
    public class ViewModule
    {
        [Required]
        public string Title { get; set; }
        
        public int MajorId { get; set; }
    }
}