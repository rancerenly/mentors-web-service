namespace MentorsWebService.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }

    }
}