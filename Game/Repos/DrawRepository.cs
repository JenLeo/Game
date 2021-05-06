using Game.Models;
using Microsoft.EntityFrameworkCore;
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

            public IEnumerable<draw> GetDraw()
            {
                return _context.draw.ToList();
            }

            public void InsertDraw(draw _draw)
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
        public async Task<draw> Create(draw _draw)
        {
            var data = new draw
            {
                DrawID = _draw.DrawID,
                DrawName = _draw.DrawName,
                draw_dt = _draw.draw_dt,
                
            };
            await _context.draw.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public IQueryable<draw> GetAll()
        {
            return _context.draw.AsQueryable();
        }

        public async Task<bool> Delete(string id)
        {
            Task<draw> dwTask = _context.draw.FirstOrDefaultAsync(p => p.DrawID == id);
            draw dw = dwTask.Result;
            if (dw == null)
            {
                return false;
            }

            _context.Remove(dw);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(draw _draw)
        {
            Task<draw> dwTask = _context.draw.FirstOrDefaultAsync(p => p.DrawID == _draw.DrawID);
            draw dw = dwTask.Result;
            if (dw == null)
            {
                return false;
            }

            dw.DrawID = _draw.DrawID;
            dw.DrawName = _draw.DrawName;
            dw.draw_dt = _draw.draw_dt;
            

            await _context.SaveChangesAsync();
            return true;
        }
    }
    }
