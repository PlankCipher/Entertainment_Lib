using Entertainment_Lib.Models;
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
            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie != null)
            {
                return View(movie);
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
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}