using Game.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Controllers
{
    public class TicketController : Controller
    {
        private readonly GameContext _context;


        public TicketController(IConfiguration configuration, IOptions<GlobalData> globalData, GameContext Context)
        {
            _context = Context;
            try
            {
                _context.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        [HttpGet]
        public IActionResult BuyTicket()
        {
            ViewBag.DrawType = new SelectList(Ticket.DrawTypes);
            return View(new Ticket()
            {
                Ticket_id = DateTime.Now.ToString().GetHashCode().ToString("x"),
                DrawType = "EuroDraw",
                Number1 = 2,
                Number2 = 5,
                Number3 = 17,
                Number4 = 22,
                Number5 = 36,
                Number6 = 41,
                purchased = DateTime.Now,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuyTicket([Bind("Ticket_id,DrawType,Number1,Number2,Number3,Number4,Number5,Number6,Price,purchased")]
            Ticket ticket)
        
        {
            ViewBag.DrawType = new SelectList(Ticket.DrawTypes);
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TicketIndex));
            }
            return View(ticket);

        }

            
        // show confirmation
        public ActionResult Confirm(Ticket _ticket)
        {
            return View(_ticket);
        }


        public async Task<IActionResult> TicketIndex()
        {
            return View(await _context.ticket.ToListAsync());
        }
        public async Task<IActionResult> Details(String id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.ticket.FirstOrDefaultAsync(m => m.Ticket_id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Ticket/Create
        [HttpGet]
        public IActionResult TicketCreate()
        {
            return View();
        }

       

        //GET: Ticket/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _ticket = await _context.ticket.FindAsync(id);
            if (_ticket == null)
            {
                return NotFound();
            }
            return View(_ticket);
        }

        // POST: Ticket/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Ticket_id,DrawType,Number1,Number2,Number3,Number4,Number5," +
                    "Number6,Price,purchased")] Ticket _ticket)
        {
            if (id != _ticket.Ticket_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(_ticket.Ticket_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_ticket
                );
        }

        // GET: Ticket/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _ticket = await _context.ticket
                .FirstOrDefaultAsync(m => m.Ticket_id == id);
            if (_ticket == null)
            {
                return NotFound();
            }

            return View(_ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var _ticket = await _context.ticket.FindAsync(id);
            _context.ticket.Remove(_ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(string id)
        {
            return _context.ticket.Any(e => e.Ticket_id == id);
        }


    }
}

