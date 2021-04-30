using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models
{
    public class LottoController : Controller
    {
        // GET: Lotto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Lotto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lotto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lotto/Create
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

        // GET: Lotto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lotto/Edit/5
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

        // GET: Lotto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lotto/Delete/5
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
