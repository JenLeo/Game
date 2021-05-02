using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Game> lotto { get; set; }

       

        //private const string connectionString = "Server=tcp:lottoead.database.windows.net,1433;" +
            //"Initial Catalog=Lotto;Persist Security Info=False;User ID=JenEAD;Password={your_password};" +
            //"MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;""


            }
}
