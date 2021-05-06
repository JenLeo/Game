using Game.Models;
using Game.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameTestP
{
    [TestClass]
    public class GameTest
    {
        //[TestMethod]
            //public async void CanCreateDraw()
            //{
            //await //
            //}
        [TestMethod]
        public void Draw()
        {
            draw myDraws = new draw() { DrawID = "123", DrawName = "DailyJackpot", date_dt = DateTime.Now };

        }
        [TestMethod]
        public void Ticket()
        { }



    }
}
