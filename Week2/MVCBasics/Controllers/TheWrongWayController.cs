using Microsoft.AspNetCore.Mvc;

namespace MVCBasics.Controllers
{
    public class TheWrongWayController : Controller
    {
        //Fields 
        Random rand;
        //Constructor
        //we have tigtly coupled code, TheWrongWay Controller has a concrete
        //Random class in it.
        public TheWrongWayController()
        {
            rand = new Random();
        }
        //All this controller needs is a number between 1 and 6
        public IActionResult Index()
        {
            int x = rand.Next(1, 7);
            int y = rand.Next(1, 7);
            return Content($"Die 1: {x} Die 2: {y}");

        }
    }
}
