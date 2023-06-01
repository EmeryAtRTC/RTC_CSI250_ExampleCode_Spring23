using AutoShop23.Models;
using AutoShop23.Validation;
using System.ComponentModel.DataAnnotations;

namespace AutoShop23.ViewModels
{
    public class VehicleCreateVM
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
        [Range(0, 10000)]
        public int Year { get; set; }
        [Required]
        [Range(0, 9999999)]
        public int Mileage { get; set; }
        [Required]
        [StringLength(17, MinimumLength = 17)]
        public string VIN { get; set; }
        //We arent storing the actual image
        //we are storing a link to it (string)
        [StringLength(100)]
        public string ImageLocation { get; set; }
        //Add a property to store the uploaded File
        [Display(Name = "Upload Vehicle Photo")]
        //We can create our own data annotations
        [VehicleImageValidation]
        public IFormFile VehicleImage { get; set; }
        //navigation properties
        //Vehicle has one customer
        public Customer Customer { get; set; }

    }
}
