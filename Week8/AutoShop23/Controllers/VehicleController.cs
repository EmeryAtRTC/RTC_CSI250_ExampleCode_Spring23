using AutoShop23.Data;
using AutoShop23.Models;
using AutoShop23.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop23.Controllers
{
    public class VehicleController : Controller
    {
        ApplicationDbContext _context;

        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        //In order to create a vehicle, we have to have a customer
        //one of the ways to accomplish this is to take
        //a customerId as a parameter to vehicle create
        [HttpGet]
        public IActionResult Create(int customerId)
        {
            if(customerId == 0)
            {
                return NotFound();
            }
            //This customer will be the owner of the vehicle
            Customer customer = _context.Customers.SingleOrDefault(x => x.Id == customerId);
            if(customer == null)
            {
                return NotFound();
            }
            //Lets make new vehicle and associate our customer with that vehicle
            VehicleCreateVM vehicleVM = new VehicleCreateVM
            {
                CustomerId = customer.Id,
                Customer = customer
            };
            return View(vehicleVM);
        }
        [HttpPost]
        public IActionResult Create(VehicleCreateVM vehicleVM) 
        {
            return Json(vehicleVM);
        }

    }
}
