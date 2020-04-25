using Entertainment_Lib.Models;
using Microsoft.AspNet.Identity;
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

        public ActionResult Details(int id)
        {
            TVProgram tvprogram = _context.TVPrograms.SingleOrDefault(m => m.Id == id);
            if (tvprogram != null)
            {
                return View(tvprogram);
            } else
            {
                return RedirectToAction("Index");
            }

        }


        [Authorize]
        public ActionResult New()
        {
            string userId = User.Identity.GetUserId();
            TVProgram model = new TVProgram()
            {
                Owner = _context.Users.FirstOrDefault(x => x.Id == userId)
            };
            return View("TVProgramForm", model);
        }

        [HttpPost]
        public ActionResult Save(TVProgram model)
        {
            if (!ModelState.IsValid)
            {
                return View("TVProgramForm", model);
            }

            string userId = User.Identity.GetUserId();
            model.Owner = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (model.Id == 0)
            {
                _context.TVPrograms.Add(model);
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}