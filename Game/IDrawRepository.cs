using Game.Models;
using System;
using System.Collections.Generic;

namespace Game
{
    internal interface IDrawRepository : IDisposable
    {
        IEnumerable<draw> GetDraw();

        void InsertDraw(draw draw);

        void Save();
    }
}
