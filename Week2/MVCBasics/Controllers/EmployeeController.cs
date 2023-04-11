using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;

namespace MVCBasics.Controllers
{
    //A controller is a C# class that inherits from Controller
    public class EmployeeController : Controller
    {
        //fields
        List<Employee> employees;
        //assign values to fields - Constructor
        //Special method that runs whenever an instance of our class is created
        public EmployeeController()
        {
            employees = new List<Employee>();
            //The old way
            Employee e1 = new Employee();
            e1.Id = 1;
            e1.FirstName = "Will";
            e1.LastName = "Cram";
            e1.EmployeeId = "WC293849";
            e1.Active = true;
            e1.Phone = "2064585743";
            //add employee to the list
            employees.Add(e1);
            //How to make a new entity model
            Employee e2 = new Employee
            {
                Id = 2,
                FirstName = "Lhoucine",
                LastName = "Zerrouki",
                EmployeeId = "LZ237483",
                Phone = "42584957689",
                Active = true
            };
            employees.Add(e2);
        }
        
        //lets add an endpoint
        //We hit this endpoint by going to host/Employee/Index
        //or host/Employee
        public IActionResult Index()
        {
            //Its going to look for a view in /Views/Employee/Index.cshtml
            //pass our list of employees to the view
            return View(employees);
        }
        //Details - It will send one employee to a view
        //Details takes in an id and sends the employee that matches the id
        //This endpoint is going to look for a view in Views/Employee/Details.cshtml
        public IActionResult Details(int id)
        {
            //loop through employees and find the matching employee
            foreach(Employee e in employees)
            {
                if(e.Id == id)
                {
                    return View(e);
                }
            }
            //if this loop ends and we did not find an employee
            //return NotFound()
            return NotFound();
        }
    }
}
