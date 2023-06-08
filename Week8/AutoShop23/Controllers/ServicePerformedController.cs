using AutoShop23.Data;
using AutoShop23.Models;
using Microsoft.AspNetCore.Mvc;

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
            return Json(vehicle);
        }
    }
}
