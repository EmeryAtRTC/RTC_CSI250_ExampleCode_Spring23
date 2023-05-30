using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AutoShop23.ViewModels
{
    public class TechCreateVM
    {
        //What goes in your ViewModel is all of information
        //That needs to either Go To OR Come Back from the View
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
        //foreign key to technicianstatus Id
        [Display(Name = "Technician Status")]
        public int TechnicianStatusId { get; set; }
        //I need to send a IEnumerable<SelectListItem>
        public IEnumerable<SelectListItem> TechStatusList { get; set; }
    }
}
