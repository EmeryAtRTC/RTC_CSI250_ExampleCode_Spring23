using AutoShop23.Data;
using AutoShop23.Models;
using AutoShop23.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoShop23.Controllers
{
    public class TechnicianController : Controller
    {
        //fields
        ApplicationDbContext _context;

        public TechnicianController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Json() does not work when using the Include() method
            //We want to load all of the technicians and Include the
            //navigation property to technician status
            //what this is going to do. It is going to pull the record
            //from technicianstatus and place it in the navigation property
            //You only have access to Include when dealing with a collection
            IEnumerable<Technician> technicians = _context.Technicians.Include(x => x.TechnicianStatus);
            return View(technicians);
        }
        //To create a Technician we have to have a techstatus
        //Either you send them to another page where they select a status and then take
        //the selected status as a parameter in Create()
        //OR
        //We include a selectlist with all of the possible statuses in the Create View()
        //Lets create a selectList with the statuses
        public IActionResult Create()
        {
            //You can use the viewbag to do this
            //I prefer to make a ViewModel (DTO - Data Transfer Object)
            //We need to create the selectlist
            IEnumerable<SelectListItem> techStatusList = _context.TechnicianStatuses.Select(x => new SelectListItem
            {
                Text = x.Status,
                Value = x.Id.ToString()
            });
            TechCreateVM techCreateVM = new TechCreateVM
            {
                TechStatusList = techStatusList
            };
            return View(techCreateVM);
        }
        [HttpPost]
        public IActionResult Create(TechCreateVM techCreateVM)
        {
            if(!ModelState.IsValid)
            {
                //repopulate the list
                techCreateVM.TechStatusList = _context.TechnicianStatuses.Select(x => new SelectListItem
                {
                    Text = x.Status,
                    Value = x.Id.ToString()
                });
                return View(techCreateVM);
            }
            //We need to create a new Technician from the techCreateVM
            Technician technician = new Technician
            {
                FirstName = techCreateVM.FirstName,
                LastName = techCreateVM.LastName,
                EmployeeNumber = techCreateVM.EmployeeNumber,
                TechnicianStatusId = techCreateVM.TechnicianStatusId
            };
            _context.Technicians.Add(technician);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Details endpoint
        public IActionResult Details(int  id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            Technician technician = _context.Technicians.SingleOrDefault(x => x.Id == id);
            if(technician == null)
            {
                return NotFound();
            }
            //Pulling the technicianstatus for our techncian and passing it to view
            //using the navigation property
            //If you have one instance of an entity and need to populate a naviation property
            //you do it by hand
            technician.TechnicianStatus = _context.TechnicianStatuses.
                SingleOrDefault(x => x.Id == technician.TechnicianStatusId);
            return View(technician);
        }
    }
}
