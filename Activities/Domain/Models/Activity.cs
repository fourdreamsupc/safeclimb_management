
namespace Activities.Domain.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        //Relationships
        public int ServiceId { get; set; }
    }
}