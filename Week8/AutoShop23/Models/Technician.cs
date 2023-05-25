using System.ComponentModel.DataAnnotations;

namespace AutoShop23.Models
{
    public class Technician
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Tech First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Tech Last Name")]
        public string LastName { get; set; }
        [Required]
        //This means that this will always be exactly 9 characters
        [StringLength(9, MinimumLength = 9)]
        public string EmployeeNumber { get; set; }
        //navigation properties
        //each technician has multiple serviceperformed
        public IEnumerable<ServicePerformed> ServicesPerformed { get; set; }

    }
}
