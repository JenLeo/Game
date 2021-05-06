using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    internal interface IDrawRepository : IDisposable
    {
        IEnumerable<draw> GetDraw();

        void InsertDraw(draw draw);

        void Save();

        Task<draw> Create(draw _draw);
        Task<bool> Update(draw _draw);
        Task<bool> Delete(string id);
        IQueryable<draw> GetAll();
    }
}
