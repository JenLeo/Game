using Game.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private readonly GameContext _context;


        public AdminController(IConfiguration configuration, IOptions<GlobalData> globalData, GameContext Context)
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

        // GET: draw
        public async Task<IActionResult> Index()
        {
            return View(await _context.draw.ToListAsync());
        }

        // GET: draw/Details/5
        public async Task<IActionResult> Details(String id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _draw = await _context.draw.FirstOrDefaultAsync(m => m.DrawID == id);
            if (_draw == null)
            {
                return NotFound();
            }

            return View(_draw);
        }

        // GET: Draw/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Draw/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrawID,DrawName,draw_dt")] draw _draw)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_draw);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_draw);
        }

        // GET: Draw/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _draw = await _context.draw.FindAsync(id);
            if (_draw == null)
            {
                return NotFound();
            }
            return View(_draw);
        }

        // POST: Draw/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DrawID,DrawName,draw_dt")] draw _draw)
        {
            if (id != _draw.DrawID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_draw);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(_draw.DrawID))
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
            return View(_draw
                );
        }

        // GET: Draw/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _draw = await _context.draw
                .FirstOrDefaultAsync(m => m.DrawID == id);
            if (_draw == null)
            {
                return NotFound();
            }

            return View(_draw);
        }

        // POST: Draw/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var _draw = await _context.draw.FindAsync(id);
            _context.draw.Remove(_draw);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(string id)
        {
            return _context.draw.Any(e => e.DrawID == id);
        }
    }
}
