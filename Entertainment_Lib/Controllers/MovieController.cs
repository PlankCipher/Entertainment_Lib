using Entertainment_Lib.Models;
using Entertainment_Lib.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entertainment_Lib.Controllers
{
    public class MovieController : Controller
    {
        // The context that represents connection
        // to the database
        public ApplicationDbContext _context { get; set; }

        public MovieController()
        {
            // Initialize the context
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: /Movie/
        public ActionResult Index()
        {
            // Get all movies from database and pass them
            // to the view
            IEnumerable<Movie> allMovies = _context.Movies.ToList();

            return View(allMovies);
        }

        // GET: /Movie/Details/<id>
        public ActionResult Details(int id)
        {
            // Get movie with the passed id from database
            Movie movie = _context.Movies.Include("Owner").SingleOrDefault(m => m.Id == id);
            
            // If there is acctually a matching entry
            // in the database
            if (movie != null)
            {
                // Pass the movie and the current user id
                // to the view through the ViewModel
                MovieHomeViewModel model = new MovieHomeViewModel()
                {
                    movie = movie,
                    currentUserId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : ""
                };
                return View(model);
            } else
            {
                // If there is no such movie in database
                // redirect to the Index action of Movie
                // controller
                return RedirectToAction("Index");
            }
        }

        // Require user to be logged in to access
        // this acction
        // GET: /Movie/New/
        [Authorize]
        public ActionResult New()
        {
            // Create a new movie instance with
            // the current user as the owner (helps
            // when submitting the form)
            string userId = User.Identity.GetUserId();
            Movie model = new Movie()
            { 
                Owner = _context.Users.FirstOrDefault(x => x.Id == userId)
            };
            return View("MovieForm", model);
        }

        // Require user to be logged to access
        // this acction
        // GET: /Movie/Edit/<id>
        [Authorize]
        public ActionResult Edit(int id)
        {
            // Get movie with the passed id from database
            Movie movie = _context.Movies.Include("Owner").SingleOrDefault(m => m.Id == id);

            // If there is acctually a matching entry
            // in the database
            if (movie != null)
            {
                // Get the current logged in user id
                string userId = User.Identity.GetUserId();
                if (movie.Owner.Id == userId)
                {
                    // If the owner id of the movie equals
                    // the current user id, then this is the
                    // owner and send the user to the edit
                    // form along with the data of the chosen
                    // movie
                    return View("MovieForm", movie);
                }
            }
            
            // If not the owner of the requested
            // movie, then redirect to the index
            // action of Movie controller
            return RedirectToAction("Index");
            
        }

        // Ensures that this action is only reachable
        // through POST requests
        // POST: /Movie/Save/
        [HttpPost]
        public ActionResult Save(Movie model)
        {
            if (!ModelState.IsValid)
            {
                // Return to the same form if the data
                // is not valid
                return View("MovieForm", model);
            }

            // Set the owner of this movie to 
            // the current logged in user
            string userId = User.Identity.GetUserId();
            model.Owner = _context.Users.FirstOrDefault(x => x.Id == userId);

            // If the model id is 0, then this is a new one
            // because the id of type "int", which has 0 as
            // its default value
            if (model.Id == 0)
            {
                // Add the new movie to the database
                _context.Movies.Add(model);
            } else
            {
                // Else, this is an editing case
                Movie movieFromDB = _context.Movies.Single(m => m.Id == model.Id);
                movieFromDB.Name = model.Name;
                movieFromDB.Description = model.Description;
            }
            // Save changes to database
            _context.SaveChanges();

            // Redirect to the index action of Movie controller
            return RedirectToAction("Index");
        }

        // GET: /Movie/Delete/<id>
        public ActionResult Delete(int id)
        {
            // Get the movie with the passed id from database
            Movie movieToDelete = _context.Movies.SingleOrDefault(m => m.Id == id);

            // If there is acctually a matching entry
            // in the database
            if (movieToDelete != null)
            {
                // Delete it from the database
                _context.Movies.Remove(movieToDelete);
                // And save changes
                _context.SaveChanges();
            }

            // Redirect to the index action of Movie controller
            return RedirectToAction("Index");
        }
    }
}