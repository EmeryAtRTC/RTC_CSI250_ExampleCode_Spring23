using AutoShop23.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoShop23.ViewModels
{
    public class SPCreateVM
    {
        public int Id { get; set; }
        public int TechnicianId { get; set; }
        public int VehicleId { get; set; }
        public int ServiceStatusId { get; set; }
        public DateTime TimePerformed { get; set; }
        public Vehicle Vehicle { get; set; }
        //SelectList that go to the view
        public IEnumerable<SelectListItem> TechnicianList { get; set; }
        public IEnumerable<ServiceStatus> ServiceStatusList { get; set; }
    }
}
