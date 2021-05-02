using Game.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Play()
        {
            ViewBag.DrawTypes = new SelectList(Ticket.DrawTypes);
            return View(new Games() { DrawID = 2 });
        }

        [HttpPost]
        public ActionResult Games(Ticket d)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", d);
            }
            else
            {
                ViewBag.DrawTypes = new SelectList(Ticket.DrawTypes);
                return View(d);
            }
        }
        // show confirmation
        public ActionResult Confirm(Ticket d)
        {
            return View(d);
        }
    }
}

