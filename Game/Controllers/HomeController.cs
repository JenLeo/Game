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
        public ActionResult Calculate(AzureCloudService service)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", service);
            }
            else
            {
                ViewBag.InstanceSize = new SelectList(AzureCloudService.InstanceSizeDescriptions);
                return View(service);
            }
        }
        // show confirmation
        public ActionResult Confirm(AzureCloudService service)
        {
            return View(service);
        }
    }
}
}
