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
            TVProgram tvprogram = _context.TVPrograms.Include("Owner").SingleOrDefault(m => m.Id == id);

            if (tvprogram != null)
            {
                TVProgramHomeViewModel model = new TVProgramHomeViewModel()
                {
                    tvprogram = tvprogram,
                    currentUserId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : ""
                };
                return View(model);
            }
            else
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

        [Authorize]
        public ActionResult Edit(int id)
        {
            TVProgram tvprogram = _context.TVPrograms.Include("Owner").SingleOrDefault(m => m.Id == id);
            if (tvprogram != null)
            {
                string userId = User.Identity.GetUserId();
                if (tvprogram.Owner.Id == userId)
                {
                    return View("TVProgramForm", tvprogram);
                }
            }

            return RedirectToAction("Index");

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
            } else
            {
                TVProgram tvprogramFromDB = _context.TVPrograms.Single(m => m.Id == model.Id);
                tvprogramFromDB.Name = model.Name;
                tvprogramFromDB.Description = model.Description;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            TVProgram tvprogramToDelete = _context.TVPrograms.SingleOrDefault(m => m.Id == id);

            if (tvprogramToDelete != null)
            {
                _context.TVPrograms.Remove(tvprogramToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}