using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
   
        internal interface ITicketRepos : IDisposable
        {
            IEnumerable<Ticket> GetTicket();

            void InsertDraw(Ticket ticket);

            void Save();

        Task<Ticket> Create(Ticket ticket);
        Task<bool> Update(Ticket ticket);
        Task<bool> Delete(string id);
        IQueryable<Ticket> GetAll();

    }
    }
