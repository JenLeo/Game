using Game.Models;
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

        }
    }
