using Game.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
        public class TicketRepository : ITicketRepos
        {
            private readonly GameContext _context;

            public TicketRepository(GameContext context)
            {
                _context = context;
            }

            public IEnumerable<Ticket> GetTicket()
            {
                return _context.ticket.ToList();
            }

            public void InsertDraw(Ticket _ticket)
            {
                _context.ticket.Add(_ticket);
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
        public async Task<Ticket> Create(Ticket ticket)
        {
            var data = new Ticket
            {
                Ticket_id = ticket.Ticket_id,
                DrawType = ticket.DrawType,
                Number1 = ticket.Number1,
                Number2 = ticket.Number2,
                Number3 = ticket.Number3,
                Number4 = ticket.Number4,
                Number5 = ticket.Number5,
                Number6 = ticket.Number6,
                purchased = ticket.purchased

            };
            await _context.ticket.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public IQueryable<Ticket> GetAll()
        {
            return _context.ticket.AsQueryable();
        }

        public async Task<bool> Delete(string id)
        {
            Task<Ticket> tkTask = _context.ticket.FirstOrDefaultAsync(p => p.Ticket_id == id);
            Ticket tk = tkTask.Result;
            if (tk == null)
            {
                return false;
            }

            _context.Remove(tk);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(Ticket ticket)
        {
            Task<Ticket> tkTask = _context.ticket.FirstOrDefaultAsync(p => p.Ticket_id == ticket.Ticket_id);
            Ticket tk = tkTask.Result;
            if (tk == null)
            {
                return false;
            }

            tk.Ticket_id = ticket.Ticket_id;
            tk.DrawType = ticket.DrawType;
            tk.Number1 = ticket.Number1;
            tk.Number2 = ticket.Number2;
            tk.Number3 = ticket.Number3;
            tk.Number4 = ticket.Number4;
            tk.Number5 = ticket.Number5;
            tk.Number6 = ticket.Number6;
            tk.purchased = ticket.purchased;
            


            await _context.SaveChangesAsync();
            return true;
        }
    }
}
