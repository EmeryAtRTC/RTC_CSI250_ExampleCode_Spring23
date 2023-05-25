using System.ComponentModel.DataAnnotations;

namespace AutoShop23.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        //we want to be able to track if a customer is active or not
        [Required]
        public bool Active { get; set; }
        //navigation properties
        //A customer can have many vehicles
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
