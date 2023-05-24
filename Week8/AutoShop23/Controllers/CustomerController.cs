using AutoShop23.Data;
using AutoShop23.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop23.Controllers
{
    public class CustomerController : Controller
    {
        //dbContext is a field
        ApplicationDbContext _context;
        //Constructor
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Customers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            //I can add the new customer to the customers table
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
