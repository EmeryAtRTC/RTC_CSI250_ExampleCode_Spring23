using AutoShop23.Data;
using Microsoft.AspNetCore.Mvc;

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
            return Json(_context.Technicians);
        }
    }
}
