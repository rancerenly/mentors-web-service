namespace MentorsWebService.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int MajorId { get; set; }
        public Major Major { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int Mark { get; set; }
        public string TextReview { get; set; }
    }
}