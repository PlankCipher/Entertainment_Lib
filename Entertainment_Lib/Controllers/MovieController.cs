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
        public ApplicationDbContext _context { get; set; }

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movie
        public ActionResult Index()
        {
            IEnumerable<Movie> allMovies = _context.Movies.ToList();

            return View(allMovies);
        }

        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.Include("Owner").SingleOrDefault(m => m.Id == id);
            
            if (movie != null)
            {
                MovieHomeViewModel model = new MovieHomeViewModel()
                {
                    movie = movie,
                    currentUserId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : ""
                };
                return View(model);
            } else
            {
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult New()
        {
            string userId = User.Identity.GetUserId();
            Movie model = new Movie()
            { 
                Owner = _context.Users.FirstOrDefault(x => x.Id == userId)
            };
            return View("MovieForm", model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.Include("Owner").SingleOrDefault(m => m.Id == id);
            if (movie != null)
            {
                string userId = User.Identity.GetUserId();
                if (movie.Owner.Id == userId)
                {
                    return View("MovieForm", movie);
                }
            }
            
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public ActionResult Save(Movie model)
        {
            if (!ModelState.IsValid)
            {
                return View("MovieForm", model);
            }

            string userId = User.Identity.GetUserId();
            model.Owner = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (model.Id == 0)
            {
                _context.Movies.Add(model);
            } else
            {
                Movie movieFromDB = _context.Movies.Single(m => m.Id == model.Id);
                movieFromDB.Name = model.Name;
                movieFromDB.Description = model.Description;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}