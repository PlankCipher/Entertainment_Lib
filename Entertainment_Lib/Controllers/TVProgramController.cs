using Entertainment_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entertainment_Lib.Controllers
{
    public class TVProgramController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public TVProgramController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: TVProgram
        public ActionResult Index()
        {
            IEnumerable<TVProgram> tvprograms = _context.TVPrograms.ToList();

            return View(tvprograms);
        }
    }
}