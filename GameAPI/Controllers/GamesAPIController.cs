using Game.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GameAPI.Controllers
{


    [Route("api/draws")]
    [ApiController]
    public class GamesAPIController : ControllerBase
    {
        public IEnumerable<draw> Get()
        {
            using (GameContext dbcontext = new GameContext())
            {
                return dbcontext.ToList();
            }
               
        }

        [Route("api/draws/1")]
        public draw Get(string Id)
        {
            using (GameContext dbcontext = new GameContext())
            {
                return dbcontext.draw.FirstOrDefault(d => d.DrawID == Id);
            }
        }

    }
}
      
