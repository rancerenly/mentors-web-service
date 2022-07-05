using System.Collections.Generic;

namespace MentorsWebService.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MajorId { get; set; }
        public Major Major { get; set; }
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}