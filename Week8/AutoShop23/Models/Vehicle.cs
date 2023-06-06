using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace AutoShop23.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Required]
        [StringLength(30)]
        public string Make { get; set; }
        [Required]
        [StringLength(30)]
        public string Model { get; set; }
        [Required]
        [Range(0,10000)]
        public int Year { get; set; }
        [Required]
        [Range(0, 9999999)]
        public int Mileage { get; set; }
        [Required]
        [StringLength(17, MinimumLength = 17)]
        public string VIN { get; set; }
        //We arent storing the actual image
        //we are storing a link to it (string)
        [Display(Name ="Vehicle Image")]
        [StringLength(100)]
        public string ImageLocation { get; set; }
        //navigation properties
        //Vehicle has one customer
        public Customer Customer { get; set; }
        //Vehicle has multiple Service Performed
        public IEnumerable<ServicePerformed> ServicesPerformed { get; set; }
    }
}
