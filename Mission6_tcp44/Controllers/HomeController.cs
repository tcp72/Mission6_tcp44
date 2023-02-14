using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6_tcp44.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_tcp44.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieLibraryDatabaseContext _contextFile { get; set; } //need be name of context file; call it a name
        //by putting the above private class at the top, it has scope of any methods in this class beneath
        //constructor
        public HomeController(ILogger<HomeController> logger, MovieLibraryDatabaseContext someName)
        {
            _logger = logger;
            _contextFile = someName; //this and the lines above get the info from context file into controller
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieLibrary()
        {
            return View();//default is to look for the "MovieLibrary" view name; (is also the name of controller referenced in the <a> tag
        }       //could say return View(otherNameBesidesMovieLibrary); if wanted to go to another view

        [HttpPost]

    public IActionResult MovieLibrary(MovieEntry me) //make variable to receive whole packet of response from the form
        {                               //MovieEntry is the name of class used to make the model and the name of that model page in general 
            _contextFile.Add(me); //propose the changes by adding the object
            _contextFile.SaveChanges(); //save changes

            return View("Confirmation", me);//send to "Confirmation" View when post this form   //create instance of MovieEntry class; "me" is the name of that instance (which is an object)
        }                               //MovieLibrary is the View name;
             //pass to the confirmation view the contents of the me object; that's so can reference "firstname" in confirmation page

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

//if I wanted to only run this portion if it was valid, for the post
//public IActionResult MovieLibrary(MovieEntry me)
//{
//    if (ModelState.IsValid)                 //if the model is valid (required fields not null) display the confirmation page
//    {
//        _contextFile.Add(me); //add the thing from the video after;
//        _contextFile.SaveChanges();
//        return View("Confirmation", me);
//    }
//    else
//    {
//        return View();                      //if model is invalid, stay on the page with the displayed error messages
//    }
//}

//********this is just missing [HttpPost]; I added the 10 or so lines above; I think it's from the videos