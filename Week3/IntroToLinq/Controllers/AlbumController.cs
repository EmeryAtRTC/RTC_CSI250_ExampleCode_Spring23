using IntroToLinq.Models;
using LinqDemo.Data;
using Microsoft.AspNetCore.Mvc;

namespace IntroToLinq.Controllers
{
    public class AlbumController : Controller
    {
        List<Album> _albums;

        public AlbumController(IAlbumList albumList)
        {
            _albums = albumList.GetAlbums();
        }
        //lets add an index - shows us all of the albums
        public IActionResult Index()
        {
            return View(_albums);
        }
        //lets try to add details - details takes an id and shows one album
        public IActionResult Details(int id)
        {
            //checking if anything came into the id
            if(id == 0)
            {
                return NotFound();
            }
            //we need to find the album that matches this id if any
            //we can filter with a linq method
            //This will get us one album that matches the id
            //or null if nothing matches
            Album album = _albums.SingleOrDefault(a => a.Id == id);
            if(album == null)
            {
                return NotFound();
            }
            return View(album);
        }
        //Create has two seperate operations
        //we have to have a get and a post
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Album album)
        {
            if (!ModelState.IsValid)
            {
                return View(album);
            }
            //An album is going to come in here
            //with the information from the form
            album.Id = _albums.Count() + 1;
            //add the album to our list
            _albums.Add(album);
            //Where should we send the user?
            //redirect can send the user to another endpoint
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //check if anything was passed to id
            if(id == 0)
            {
                return NotFound();
            }
            
            Album a = _albums.SingleOrDefault(a => a.Id == id);
            //check if the album is null
            if(a == null)
            {
                return NotFound();
            }
            //send the album to the view
            // Views/Album/Edit.cshtml
            return View(a);
        }
        [HttpPost]
        public IActionResult Edit(Album model)
        {
            //We also need to validate all information on the server side
            //ModelState object - contains information about the model
            if (!ModelState.IsValid)
            {
                //send the user back to the view with the error messages
                return View(model);
            }
            //we need to get the album out of the database
            Album album = _albums.SingleOrDefault(a => a.Id == model.Id);
            //check if album is null
            if(album == null)
            {
                return NotFound();
            }
            album.Title = model.Title;
            album.Genre = model.Genre;
            album.Price = model.Price;
            album.Artist = model.Artist;
            //what page should we route them to
            //Lets route them to details of the album
            //Album details needs an ID
            return RedirectToAction("Details", new {id = album.Id});
        }


    }
}
