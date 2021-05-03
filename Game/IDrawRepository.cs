using Game.Models;
using System;
using System.Collections.Generic;

namespace Game
{
    internal interface IDrawRepository : IDisposable
    {
        IEnumerable<Draw> GetDraw();

        void InsertDraw(Draw draw);

        void Save();
    }
}
