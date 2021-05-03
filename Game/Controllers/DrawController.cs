using Game.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Controllers
{
    public class DrawController : Controller
    {
        // GET: DrawController
        private readonly IDrawRepository _repository;

        public DrawController(DrawRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetDraw().ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(draw _draw)
        {
            if (ModelState.IsValid)
            {
                _repository.InsertDraw(_draw);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(_draw);
        }
    }
}
