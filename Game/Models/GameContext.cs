using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Game.Models
{
    public class GameContext : DbContext
    {

        private const string connectionString = "Server=tcp:lottoead.database.windows.net,1433; Initial Catalog=Lotto;Persist Security Info=False;User ID=JenEAD;Password={LottoEAD123}; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public IEnumerable<draw> ToList()
        {
            throw new NotImplementedException();
        }



        public GameContext(DbContextOptions<GameContext> options)
: base(options)
        {
        }
        public DbSet<Games> lottoGame { get; set; }

        public DbSet<Ticket> ticket { get; set; }
        public DbSet<draw> draw { get; set; }

        public GameContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("Server=tcp:lottoead.database.windows.net,1433;" +
        "Initial Catalog=Lotto;Persist Security Info=False;User ID=JenEAD;Password={LottoEAD123};" +
        "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }




    }
}
