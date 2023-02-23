using System.ComponentModel.DataAnnotations;

namespace MentorsWebService.Models
{
    public class ViewMajor
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}