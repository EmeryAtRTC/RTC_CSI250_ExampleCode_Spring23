using IntroToLinq.Models;
using IntroToLinq.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace IntroToLinq.Controllers
{
    public class AlbumController : Controller
    {
        List<Album> _albums;
        List<Publisher> _publishers;

        public AlbumController(IAlbumList albumList, IPublisherList publisherList)
        {
            _albums = albumList.GetAlbums();
            _publishers = publisherList.GetPublishers();
        }
        //lets add an index - shows us all of the albums
        public IActionResult Index(string genre, string title)
        {
            //lets get all of the distinct genres from the database
            //Select()
            IEnumerable<string> genres = _albums.Select(x => x.Genre).Distinct();
            //What I need is a collection of SelectListItem
            //SelectListItem has two properties
            //Text, Value, Selected
            IEnumerable<SelectListItem> selectList = genres.Select(x => new SelectListItem
            {
                Text = x,
                Value = x,
                Selected = x == genre
            });
            //There is a collection called the ViewBag
            //It is automatically sent to every view
            //Add my selectList to the ViewBag
            ViewBag.genreList = selectList;

            //Check to see if genre was passed a value
            if (!String.IsNullOrEmpty(genre))
            {
                //we can filter on genre
                //How do I filter the collection of album 
                //for multiple results use where
                IEnumerable<Album> filteredAlbums = _albums.Where(x => x.Genre == genre);
                //Go through the list of publishers a populate the Publisher property
                foreach (Album a in _albums)
                {
                    //Assign the publisher property to the publisher that we load from the publishers list
                    a.Publisher = _publishers.SingleOrDefault(x => x.Id == a.PublisherId);
                }
                return View(filteredAlbums);
            }
            //Check to see if a title was passed
            if (!String.IsNullOrEmpty(title))
            {
                //filter on the title
                IEnumerable<Album> filteredAlbums = _albums.Where(x => x.Title.ToLower().Contains(title.ToLower()));
                //Go through the list of publishers a populate the Publisher property
                foreach (Album a in filteredAlbums)
                {
                    //Assign the publisher property to the publisher that we load from the publishers list
                    a.Publisher = _publishers.SingleOrDefault(x => x.Id == a.PublisherId);
                }
                return View(filteredAlbums);
            }

            //Go through the list of publishers a populate the Publisher property
            foreach (Album a in _albums)
            {
                //Assign the publisher property to the publisher that we load from the publishers list
                a.Publisher = _publishers.SingleOrDefault(x => x.Id == a.PublisherId);
            }
            return View(_albums);
        }
        //lets try to add details - details takes an id and shows one album
        public IActionResult Details(int id)
        {
            //checking if anything came into the id
            if (id == 0)
            {
                return NotFound();
            }
            //we need to find the album that matches this id if any
            //we can filter with a linq method
            //This will get us one album that matches the id
            //or null if nothing matches
            Album album = _albums.SingleOrDefault(a => a.Id == id);
            if (album == null)
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
            if (id == 0)
            {
                return NotFound();
            }

            Album a = _albums.SingleOrDefault(a => a.Id == id);
            //check if the album is null
            if (a == null)
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
            if (album == null)
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
            return RedirectToAction("Details", new { id = album.Id });
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            //we use the ID to pull the album from the database
            Album a = _albums.SingleOrDefault(x => x.Id == id);
            //then we check if the album is null
            if (a is null)
            {
                return NotFound();
            }
            //if we make it down here we know that we got an album from the database
            return View(a);
        }
        [HttpPost]
        public IActionResult Delete(Album album)
        {
            if(album.Id == 0)
            {
                return NotFound();
            }
            //we pull the album to delete from the database
            Album albumToDelete = _albums.SingleOrDefault(x => x.Id == album.Id);
            //we check for null
            if(album is null)
            {
                return NotFound();
            }
            //now we are ready to delete
            _albums.Remove(albumToDelete);
            //redirect to the index view
            return RedirectToAction("Index");
        }
        public IActionResult AlbumsByPublisher(int publisherId)
        {
            //IEnumerable<album> where the publiserId matches what came in here
            IEnumerable<Album> filteredAlbums = _albums.Where(x => x.PublisherId == publisherId).Select(a => new Album
            {
                Id = a.Id,
                Artist = a.Artist,
                Price = a.Price,
                Genre = a.Genre,
                PublisherId = a.PublisherId,
                Title = a.Title,
                //Population this navigation property
                Publisher = _publishers.SingleOrDefault(p => p.Id == publisherId)
            });
            return Json(filteredAlbums);
        }

    }
}
