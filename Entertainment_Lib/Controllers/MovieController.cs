using Entertainment_Lib.Models;
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
    }
}