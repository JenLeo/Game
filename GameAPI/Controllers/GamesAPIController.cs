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
        //private List<draw> draws;

       
//        public GamesAPIController()
//        {
//            draws = new List<draw>()
//                {
//                    new draw {DrawID = "RG3298", DrawName = "MillionPlus", draw_dt = DateTime.Now},
//                    new draw {DrawID = "BM7623", DrawName = "EuroDraw", draw_dt = DateTime.Now},
//                    new draw {DrawID = "GK5394", DrawName = "MillionPlus", draw_dt = DateTime.Now},
//                    new draw {DrawID = "MS0986", DrawName = "DailyJackpot", draw_dt = DateTime.Now}
//                };
//        }

//        // GET api/<GamesController>
//        public IHttpActionResult GetAllDraws()
//        {
//            return (IHttpActionResult)Ok(draws.OrderBy(s => s.DrawID).ToList());
//        }
      
//    }
//}
