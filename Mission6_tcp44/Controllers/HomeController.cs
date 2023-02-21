using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6_tcp44.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; //this is the querying link
using System.Threading.Tasks;

namespace Mission6_tcp44.Controllers
{
    public class HomeController : Controller
    {
        private MovieLibraryDatabaseContext mlContext { get; set; } //need be name of context file; call it a name
        //by putting the above private class at the top, it has scope of any methods in this class beneath
        //constructor
        public HomeController(MovieLibraryDatabaseContext someName)
        {
            mlContext = someName; //this and the lines above get the info from context file into controller
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
        {            //can name is whatever want below. here chose "Categories"
            ViewBag.Categories = mlContext.Categories.ToList(); //pass the contents of the Categories table to a list and make it available here
            return View();//default is to look for the "MovieLibrary" view name; (is also the name of controller referenced in the <a> tag
        }       //could say return View(otherNameBesidesMovieLibrary); if wanted to go to another view

        [HttpPost]
    public IActionResult MovieLibrary(MovieEntry me) //make variable to receive whole packet of response from the form
        {                               //MovieEntry is the name of class used to make the model and the name of that model page in general 
            if (ModelState.IsValid)
            {
            mlContext.Add(me); //propose the changes by adding the object
            mlContext.SaveChanges(); //save changes

            return View("Confirmation", me);//send to "Confirmation" View when post this form   //create instance of MovieEntry class; "me" is the name of that instance (which is an object)
            }
            else //if Invalid
            {
                ViewBag.Categories = mlContext.Categories.ToList();
                return View(me);
            }
        }                               //MovieLibrary is the View name;
                                        //pass to the confirmation view the contents of the me object; that's so can reference "firstname" in confirmation page

        public IActionResult Waitlist() //this will be for reading the data
        {
            var movies = mlContext.responses //retrieves the responses, orders them, puts them in a list; this is all from database
                .Include(x => x.Category) 
                //.Where(x => x.CreeperStalker == false) //could use x or blah
                .OrderBy(x => x.Category)
                .ToList();
            return View(movies); //return all movie entries to the "Waitlist" view
        }

        [HttpGet]
        public IActionResult Edit(int movieid) //same as what is in the startup file and that is passed in the route
        {
            ViewBag.Categories = mlContext.Categories.ToList(); //if they want to edit, send to ViewBag first

            var entry = mlContext.responses.Single(x => x.MovieId == movieid); //They can click on a single attribute; "entry" is my chosen var name
                        //x.MovieID is from the model. movieid is from the startup and what is passed in the url in waitlist "edit"
            return View("MovieLibrary", entry); //This is the view MovieLibrary; pass "entry" variable from above
        }
        [HttpPost]
        public IActionResult Edit(MovieEntry blah) //model MovieEntry and chosen alias
        {
            if (ModelState.IsValid)
            {
                mlContext.Update(blah);
                mlContext.SaveChanges();
                return RedirectToAction("Waitlist");//rather than seeing the Waitlist, redirect gives the waitlist action and pulls the records
            }
            else
            {
                return View("MovieLibrary");
            }
            
        }
        [HttpGet]
        public IActionResult Delete(int movieid) //we'll follow same logic as the "Edit()"
        {
            var movie = mlContext.responses.Single(x => x.MovieId == movieid); //go to the context file, which is liason to db, responses table, grab 1 record
            return View(movie); //acho "movie" is just variable. That hasthe records that we want stored in it
        }
        [HttpPost]
        public IActionResult Delete(MovieEntry me) //make object of type MovieEntry
        {
            mlContext.responses.Remove(me);
            mlContext.SaveChanges();

            return RedirectToAction("Waitlist");
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