namespace Reviews.Domain.Models
{
    public class ServiceReview
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; } 
        public double Score { get; set; }
        
        //Relationships
        public int ServiceId { get; set; } 
        public int CustomerId { get; set; }
    }
}