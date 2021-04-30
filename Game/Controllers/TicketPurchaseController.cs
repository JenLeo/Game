using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Controllers
{
    public class TicketPurchaseController : Controller
    {

        // GET: TicketPurchaseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TicketPurchaseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketPurchaseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketPurchaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: TicketPurchaseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TicketPurchaseController/Edit/5
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

        // GET: TicketPurchaseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketPurchaseController/Delete/5
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
