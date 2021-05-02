using Game.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameAPI.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class GamesAPIController : ControllerBase
    {

        static List<Games> _games = new List<Games>()
            {
        new Games(){DrawID = 002, TicketId =234, WinningNumbers="3, 6, 18, 20, 44, 46"},
        new Games(){DrawID = 001, TicketId =345, WinningNumbers ="2, 8, 19, 28, 32, 40"},
        new Games(){DrawID = 003, TicketId =564, WinningNumbers = "6, 9, 11, 19, 27, 33"}
        };
        // GET: api/<GamesController>
        [HttpGet]
        public IEnumerable<Games> Get()
        {
            return _games.OrderByDescending(p => p.DrawID);
        }

        public IActionResult Get(int id)
        {
            Games foundGame = _games.FirstOrDefault(p => p.DrawID == id);
            if (foundGame != null)
            {
                return Ok(foundGame);
            }
            return NotFound("NONE FOUND");
        }


        // POST api/<GamesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
