using System.ComponentModel.DataAnnotations;

namespace MentorsWebService.Models
{
    public class Review
    {
        public int Id { get; set; }
        public Major Major { get; set; }
        public Client Client { get; set; }
        
        [Range(1, 5, ErrorMessage = "Недопустимое значение для оценки")]
        public int Mark { get; set; }
        
        [Required]
        public string TextReview { get; set; }
    }
}