using System.ComponentModel.DataAnnotations;

namespace AutoShop23.Models
{
    public class ServiceStatus
    {
        public int Id { get; set; }
        [StringLength(20)]
        [Required]
        public string Status { get; set; }
        //Navigation Property
        public IEnumerable<ServicePerformed> ServicesPerformed { get; set; }

    }
}
