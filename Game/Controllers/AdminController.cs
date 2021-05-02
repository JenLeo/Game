using Game.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Game.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public GameContext db = new();
        public ViewResult AdminIndex(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "DrawType_desc" : "";
            var draws = from d in db.draw
                        select d;
            switch (sortOrder)
            {
                default:
                    draws = draws.OrderBy(s => s.DrawName);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                draws = draws.Where(b => b.DrawName.Contains(searchString));
            }
            return View(draws.ToList());
            
        }

        // GET: AdminController/Details/5
       public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Draw draw = db.draw.Find(id);
            if (draw == null)
            {
                return HttpNotFound();
            }
            return View(draw);

        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int DrawID, String TicketId, DateTime draw_dt)
 {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("" , "Unable to perform task");
            }
            return View(draw_dt);
            // POST: AdminController/Create
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
