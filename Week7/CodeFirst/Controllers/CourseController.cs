using CodeFirst.Data;
using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodeFirst.Controllers
{
    public class CourseController : Controller
    {
        //Add SchoolDbContext as a field
        SchoolDbContext _context;
        //Constructor
        public CourseController(SchoolDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Course> courses = _context.Courses;
            return Json(courses);
        }
        //lets do a details endpoint
        public IActionResult Details(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            //now we get the course from the database
            Course c = _context.Courses.SingleOrDefault(x => x.Id == id);
            if(c is null)
            {
                return NotFound();
            }
            return Json(c);
        }
        //lets do a create
        [HttpGet]
        public IActionResult Create()
        {
            //A course has a department. To create a course we need to know
            //which department it is in
            IEnumerable<SelectListItem> selectListDepartment = _context.Departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            });
            ViewBag.SelectListDepartment = selectListDepartment;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<SelectListItem> selectListDepartment = _context.Departments.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                });
                ViewBag.SelectListDepartment = selectListDepartment;
                return View(course);
            }
            //Down here we know the model is valid
            _context.Courses.Add(course);
            //We have to call a method called save changes
            //The SQL statement does not actually run until you call save changes
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        //Lab assigment this week, we will do as group tuesday.
        //Atempt to get it done, will be graded as complete/incomplete
        //Meaning that if you attempted it you got it
        //Edit Get and Post. Get takes in an ID
        //_context.Courses.Update()
        //Delete 
        //_context.Courses.Remove()
    }
}
