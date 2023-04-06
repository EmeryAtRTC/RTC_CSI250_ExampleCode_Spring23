using Microsoft.AspNetCore.Mvc;

namespace IntroToDotNet.Controllers
{
    public class CustomerController : Controller
    {
        //I would get to this action by going to /Customer/Index
        public IActionResult Index()
        {
            return Content("Hello from /Customer/Index");
            
        }
        //We hit this with /Customer/Random
        //lets make an enpoint that takes in a min and a max
        //and gives us a random number between min and max
        public IActionResult Random(int min, int max)
        {
            //we need the Random class
            Random rand = new Random();
            int number = rand.Next(min, max);
            return Content($"The number is {number}");
        }
    }
}
