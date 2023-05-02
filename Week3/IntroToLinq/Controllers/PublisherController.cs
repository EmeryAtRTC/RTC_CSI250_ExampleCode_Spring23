using IntroToLinq.Data;
using IntroToLinq.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroToLinq.Controllers
{
    public class PublisherController : Controller
    {
        //fields
        List<Album> _albums;
        List<Publisher> _publishers;

        public PublisherController(IAlbumList albumList, IPublisherList publisherList)
        {
            _albums = albumList.GetAlbums();
            _publishers = publisherList.GetPublishers();
        }

        public IActionResult Index()
        {
            return Json(_publishers);
        }
        //Lets imagine an endpoint that takes an albumId and returns the publisher
        public IActionResult PublisherForAlbum(int albumId)
        {
            //Try to find the publisher based on an albumId
            //We cant go through publishers and find and albumID
            //we have to go through albums first, get the album
            //Then use the publisherID of the album to get the publisher
            Album a = _albums.SingleOrDefault(x => x.Id == albumId);
            //now I have the album, how can I get the publisher?
            Publisher p = _publishers.SingleOrDefault(x => x.Id == a.PublisherId);
            return Json(p);
        }
    }
}
