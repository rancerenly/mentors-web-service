using System.ComponentModel.DataAnnotations;

namespace MentorsWebService.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public Module Module { get; set; }

    }
}