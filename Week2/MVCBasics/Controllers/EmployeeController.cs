using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;

namespace MVCBasics.Controllers
{
    public class EmployeeController : Controller
    {
        //fields
        List<Employee> employees;

        public EmployeeController()
        {
            //constructor assigns values to the fields
            //new up the employee list
            employees = new List<Employee>();
            //hard code some employees
            Employee e1 = new Employee();
            e1.Id = 1;
            e1.FirstName = "Will";
            e1.LastName = "Cram";
            e1.EmployeeId = "WC29183";
            e1.Active = true;
            //add employee to list
            employees.Add(e1);
            //new syntax
            Employee e2 = new Employee
            {
                Id = 2,
                FirstName = "Lhoucine",
                LastName = "Zerrouki",
                EmployeeId = "LZ23984",
                Active = true
            };
            employees.Add(e2);
            employees.Add(new Employee
            {
                Id = 3,
                FirstName = "Dimpy",
                LastName = "Gill",
                EmployeeId = "DG12398",
                Active = false
            });
        }
        //Create an Endpoint
        //We hit this enpoint with /Employee/Index
        //Modified our Index Enpoint to filter by active employees
        public IActionResult Index(bool filterByActive = false)
        {
            if (filterByActive)
            {
                List<Employee> filteredEmployees = new List<Employee>();
                foreach(Employee e in employees)
                {
                    if (e.Active)
                    {
                        filteredEmployees.Add(e);
                    }
                }
                return View(filteredEmployees);
            }
            return View(employees);
        }
        //Details endpoint that only shows 1 employee
        //takes in an ID (primary key)
        public IActionResult Details(int id)
        {
            //Before we go through the list, lets make sure
            //id has a value
            if(id == 0)
            {
                //this sends a 404
                return NotFound();
            }

            //Check for an employee that matches the id
            Employee employee;
            foreach(Employee e in employees)
            {
                if(e.Id == id)
                {
                    employee = e;
                    return View(employee);
                }
            }
            return NotFound();           
        }
        

    }
}
