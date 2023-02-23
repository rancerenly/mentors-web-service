using System.ComponentModel.DataAnnotations;

namespace MentorsWebService.Models
{
    public class ViewExercise
    {
        public int ModuleId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}