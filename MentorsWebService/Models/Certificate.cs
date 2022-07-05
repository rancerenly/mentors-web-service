namespace MentorsWebService.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }
        
        public int MajorId { get; set; }
        public Major Major { get; set; }
    }
}