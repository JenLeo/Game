using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{ 
        public class DrawRepository : IDrawRepository
        {
            private readonly GameContext _context;

            public DrawRepository(GameContext context)
            {
                _context = context;
            }

            public IEnumerable<Draw> GetDraw()
            {
                return _context.draw.ToList();
            }

            public void InsertDraw(Draw _draw)
            {
                _context.draw.Add(_draw);
            }

            public void Save()
            {
                _context.SaveChanges();
            }

            private bool _disposed;

            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        _context.Dispose();
                    }
                }
                _disposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

        }
    }
