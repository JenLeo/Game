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
    public class TicketController : Controller
    {
        [HttpGet]
        public ActionResult BuyTicket()
        {
            ViewBag.DrawType = new SelectList(Ticket.DrawTypes);
            return View(new Ticket() { DrawType = "EuroDraw", Number1 = 2, Number2 = 5, Number3 = 17,
            Number4=22, Number5=36,Number6=41});
        }
         
        [HttpPost]
        public ActionResult BuyTicket(Ticket ticket)
        {
            ViewBag.DrawType = new SelectList(Ticket.DrawTypes);
            
            return View(ticket);
        }
        // show confirmation
        public ActionResult Confirm(Ticket ticket)
        {
            return View(ticket);
        }
    }
}

