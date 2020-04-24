using Entertainment_Lib.Models;
using Entertainment_Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace Entertainment_Lib.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel()
            {
                latestMovies = _context.Movies.Take(5).ToList(),
                latestTVPrograms = _context.TVPrograms.Take(5).ToList()
            };

            return View(model);
        }
    }
}