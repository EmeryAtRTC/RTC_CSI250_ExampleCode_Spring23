using AutoShop23.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AutoShop23.ViewModels
{
    public class SPCreateVM
    {
        public int Id { get; set; }
        public int TechnicianId { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public int ServiceStatusId { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        public DateTime TimePerformed { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
        //SelectList that go to the view
        public IEnumerable<SelectListItem> TechnicianList { get; set; }
        public IEnumerable<SelectListItem> ServiceStatusList { get; set; }
    }
}
