using AutoShop23.Data;
using AutoShop23.Models;
using AutoShop23.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoShop23.Controllers
{
    public class ServicePerformedController : Controller
    {
        ApplicationDbContext _context;

        public ServicePerformedController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Create(int vehicleId)
        {
            if(vehicleId == 0)
            {
                return NotFound();
            }
            Vehicle vehicle = _context.Vehicles.SingleOrDefault(x => x.Id == vehicleId);
            if(vehicle == null)
            {
                return NotFound(vehicleId);
            }
            SPCreateVM sPCreateVM = new SPCreateVM
            {
                Vehicle = vehicle,
                TimePerformed = DateTime.Now,
                //We just made a made SelectList from our servicestatus
                ServiceStatusList = _context.ServiceStatuses.Select(x => new SelectListItem
                {
                    Text = x.Status,
                    Value = x.Id.ToString()
                }),
                TechnicianList = _context.Technicians.Select(x => new SelectListItem
                {
                    Text = $"{x.LastName}: {x.EmployeeNumber}",
                    Value = x.Id.ToString()
                }),
                Customer = _context.Customers.SingleOrDefault(x => x.Id == vehicle.CustomerId),
                CustomerId = vehicle.CustomerId
            };
            return View(sPCreateVM);
        }
        [HttpPost]
        public IActionResult Create(SPCreateVM sPCreateVM)
        {
            if (!ModelState.IsValid)
            {
                sPCreateVM.ServiceStatusList = _context.ServiceStatuses.Select(x => new SelectListItem
                {
                    Text = x.Status,
                    Value = x.Id.ToString()
                });
                sPCreateVM.TechnicianList = _context.Technicians.Select(x => new SelectListItem
                {
                    Text = $"{x.LastName}: {x.EmployeeNumber}",
                    Value = x.Id.ToString()
                });
                sPCreateVM.Vehicle = _context.Vehicles.SingleOrDefault(x => x.Id == sPCreateVM.VehicleId);
                sPCreateVM.Customer = _context.Customers.SingleOrDefault(x => x.Id == sPCreateVM.Customer.Id);
                //Run null checks
                return View(sPCreateVM);
            }
            //If we make it down here we know the model is valid
            ServicePerformed sp = new ServicePerformed
            {
                ServiceStatusId = sPCreateVM.ServiceStatusId,
                TechnicianId = sPCreateVM.TechnicianId,
                VehicleId = sPCreateVM.VehicleId,
                Notes = sPCreateVM.Notes,
                TimePerformed = sPCreateVM.TimePerformed
            };
            _context.ServicesPerformed.Add(sp);
            _context.SaveChanges();
            return Json(sp);
            
        }
    }
}
