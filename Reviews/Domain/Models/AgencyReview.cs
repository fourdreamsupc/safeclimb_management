
namespace Reviews.Domain.Models
{
    public class AgencyReview
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public double ProfessionalismScore { get; set; }
        public double SecurityScore { get; set; }
        public double QualityScore { get; set; }
        public double CostScore { get; set; }
    
        public int AgencyId { get; set; }
        public int CustomerId { get; set; }
    }
}