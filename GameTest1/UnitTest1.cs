using Game.Models;
using System;
using Xunit;

namespace GameTest1
{
    public class UnitTest1
    {
        [Fact]
        public void DrawTest()
        {
            //arrange
            draw d = new draw() { DrawID = "123", DrawName = "DailyJackpot", date_dt = DateTime.Now };
            
            //act
            //assert
            //Assert.IsInstanceOfType(d, typeof(draw));
            //Assert.AreEqual(d.DrawID, "123");
            //Assert.AreEqual(d.DrawName, "DailyJackpot");
            //Assert.AreEqual(d.date_dt, DateTime.Now);


        }
    }
}
