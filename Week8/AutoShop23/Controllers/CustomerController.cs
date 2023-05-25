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
            //we only want the active customers
            return View(_context.Customers.Where(x => x.Active));
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
        //Edit requires a get and post
        //get takes in an id and pulls the customer to be edited out of the database
        //passes that customer as the model
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            Customer customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer is null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            //This is the old way
            //Customer c = _context.Customers.SingleOrDefault(x => x.Id == customer.Id);
            //c.FirstName = customer.FirstName;
            //c.LastName = customer.LastName;
            //c.Phone = customer.Phone;
            //_context.SaveChanges();
            //check if model is valid
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            //Update the customer
            //This technique is easier but.. This only works when your object is one of the
            //entity models
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            Customer customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if(customer is null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            if(customer.Id == 0)
            {
                return NotFound();
            }
            //use the id that came back to pull the customer
            Customer c = _context.Customers.SingleOrDefault(x => x.Id == customer.Id);
            if(c is null)
            {
                return NotFound();
            }
            //we are simulating delete. This is not actually deleting the customer from the database
            c.Active = false;
            _context.Customers.Update(c);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
