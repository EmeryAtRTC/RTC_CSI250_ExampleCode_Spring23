using AutoShop23.Data;
using AutoShop23.Models;
using AutoShop23.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoShop23.Controllers
{
    public class VehicleController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment _environment;
        

        public VehicleController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        //In order to create a vehicle, we have to have a customer
        //one of the ways to accomplish this is to take
        //a customerId as a parameter to vehicle create
        //Authorize means that this endpoint can only be access by users who are logged in
        [Authorize]
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
            if (!ModelState.IsValid)
            {
                //This customer will be the owner of the vehicle
                Customer customer = _context.Customers.SingleOrDefault(x => x.Id == vehicleVM.CustomerId);
                vehicleVM.Customer = customer;
                if (customer == null)
                {
                    return NotFound();
                }
                return View(vehicleVM);
            }
            //save the file and get the new file name
            string imageLocation = SaveUploadedFile(vehicleVM.VehicleImage);
            //Create a vehicle from our VehicleCreateVM
            Vehicle vehicle = new Vehicle
            {
                CustomerId= vehicleVM.CustomerId,
                Make = vehicleVM.Make,
                Model = vehicleVM.Model,
                Year = vehicleVM.Year,
                VIN = vehicleVM.VIN,
                Mileage = vehicleVM.Mileage,
                ImageLocation = imageLocation
            };
            //Add the vehicle to the database
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            IEnumerable<Vehicle> vehicles = _context.Vehicles.Include(x=>x.Customer);
            return View(vehicles);
        }
        public IActionResult Details(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            Vehicle vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == id);
            if(vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        //lets make a method that takes a file, gives it a random file name
        //saves the file and returns the new filename as a string
        private string SaveUploadedFile(IFormFile file)
        {
            if(file != null)
            {
                //First thing we need to determine
                //What folder do we want to store this in
                //the current path can be access by the environment object
                string folder = Path.Combine(_environment.WebRootPath, "Images");
                //Generate a random file name
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string fullFilePath = Path.Combine(folder, fileName);
                //Save the file to wwwroot/Images
                using (FileStream fs = new FileStream(fullFilePath, FileMode.Create))
                {
                    file.CopyTo(fs);
                }
                return fileName;
            }
            return "";
        }

    }
}
