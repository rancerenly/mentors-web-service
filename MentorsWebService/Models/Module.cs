using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MentorsWebService.Models
{
    public class Module
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        public Major Major { get; set; }
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}