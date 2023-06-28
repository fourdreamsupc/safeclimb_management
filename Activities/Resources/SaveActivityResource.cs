using System.ComponentModel.DataAnnotations;

namespace Activities.Resources
{
    public class SaveActivityResource
    {
        
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public int ServiceId { get; set; }
    }
}