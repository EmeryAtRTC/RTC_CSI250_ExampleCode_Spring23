using Microsoft.AspNetCore.Mvc;
using MVCBasics.Services;

namespace MVCBasics.Controllers
{
    public class TheRightWayController : Controller
    {
        //Field - Rely on the abstraction
        IDiceRoller _diceRoller;
        //We asked for a class that implements Idiceroller in the constructor
        public TheRightWayController(IDiceRoller diceRoller)
        {
            _diceRoller = diceRoller;
        }
        //Inside this index method I can only get a number between 1 - 6
        public IActionResult Index()
        {
            int x = _diceRoller.RollDice();
            int y = _diceRoller.RollDice();
            return Content($"Die 1: {x} Die 2: {y}");
        }
        //Endpoint InjectView
        //TheRightWay/InjectView
        public IActionResult InjectView()
        {
            return View();
        }
    }
}
