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
        // The context that represents connection
        // to the database
        private ApplicationDbContext _context { get; set; }

        public TVProgramController()
        {
            // Initialize the context
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: /TVProgram/
        public ActionResult Index()
        {
            // Get all tv programs from database and pass
            // them to the view
            IEnumerable<TVProgram> tvprograms = _context.TVPrograms.ToList();

            return View(tvprograms);
        }

        // GET: /TVProgram/Details/<id>
        public ActionResult Details(int id)
        {
            // Get tv progarm with the passed id from database
            TVProgram tvprogram = _context.TVPrograms.Include("Owner").SingleOrDefault(m => m.Id == id);

            // If there is acctually a matching entry
            // in the database
            if (tvprogram != null)
            {
                // Pass the tv program and the current user id
                // to the view through the ViewModel
                TVProgramHomeViewModel model = new TVProgramHomeViewModel()
                {
                    tvprogram = tvprogram,
                    currentUserId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : ""
                };
                return View(model);
            }
            else
            {
                // If there is no such tv program in database
                // redirect to the Index action of TVProgram
                // controller
                return RedirectToAction("Index");
            }

        }

        // Require user to be logged in to access
        // this acction
        // GET: /TVProgram/New/
        [Authorize]
        public ActionResult New()
        {
            // Create a new tv program instance with
            // the current user as the owner (helps
            // when submitting the form)
            string userId = User.Identity.GetUserId();
            TVProgram model = new TVProgram()
            {
                Owner = _context.Users.FirstOrDefault(x => x.Id == userId)
            };
            return View("TVProgramForm", model);
        }

        // Require user to be logged to access
        // this acction
        // GET: /TVProgram/Edit/<id>
        [Authorize]
        public ActionResult Edit(int id)
        {
            // Get movie with the passed id from database
            TVProgram tvprogram = _context.TVPrograms.Include("Owner").SingleOrDefault(m => m.Id == id);

            // If there is acctually a matching entry
            // in the database
            if (tvprogram != null)
            {
                // Get the current logged in user id
                string userId = User.Identity.GetUserId();
                if (tvprogram.Owner.Id == userId)
                {
                    // If the owner id of the tv program equals
                    // the current user id, then this is the
                    // owner and send the user to the edit
                    // form along with the data of the chosen
                    // movie
                    return View("TVProgramForm", tvprogram);
                }
            }

            // If not the owner of the requested
            // tv program, then redirect to the index
            // action of TVProgram controller
            return RedirectToAction("Index");

        }


        // Ensures that this action is only reachable
        // through POST requests
        // POST: /TVProgram/Save/
        [HttpPost]
        public ActionResult Save(TVProgram model)
        {
            if (!ModelState.IsValid)
            {
                // Return to the same form if the data
                // is not valid
                return View("TVProgramForm", model);
            }

            // Set the owner of this tv program to 
            // the current logged in user
            string userId = User.Identity.GetUserId();
            model.Owner = _context.Users.FirstOrDefault(x => x.Id == userId);

            // If the model id is 0, then this is a new one
            // because the id of type "int", which has 0 as
            // its default value
            if (model.Id == 0)
            {
                // Add the new movie to the database
                _context.TVPrograms.Add(model);
            } else
            {
                // Else, this is an editing case
                TVProgram tvprogramFromDB = _context.TVPrograms.Single(m => m.Id == model.Id);
                tvprogramFromDB.Name = model.Name;
                tvprogramFromDB.Description = model.Description;
            }
            // Save changes to database
            _context.SaveChanges();

            // Redirect to the Index action of TVProgram controller
            return RedirectToAction("Index");
        }

        // GET: /TVProgram/Delete/<id>
        public ActionResult Delete(int id)
        {
            // Get the tv program with the passed id from database
            TVProgram tvprogramToDelete = _context.TVPrograms.SingleOrDefault(m => m.Id == id);

            // If there is acctually a matching entry
            // in the database
            if (tvprogramToDelete != null)
            {
                // Delete it from the database
                _context.TVPrograms.Remove(tvprogramToDelete);
                // And save changes
                _context.SaveChanges();
            }

            // Redirect to the Index action of TVProgram controller
            return RedirectToAction("Index");
        }
    }
}