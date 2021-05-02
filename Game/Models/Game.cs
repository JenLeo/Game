using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Game.Models
{
    public class Game
    {

        // azure connection string;
        // Server=tcp:lottoead.database.windows.net,1433;Initial Catalog=Lotto;Persist Security Info=False;User ID=JenEAD;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
        [Required]
        public int DrawID { get; set; }
        public int TicketId { get; set; }

        public string WinningNumbers { get; set; }

        private Random random;

        public Game()
        {
            random = new Random();
            int number_1 = random.Next(1, 49);
            int number_2 = random.Next(1, 49);
            int number_3 = random.Next(1, 49);
            int number_4 = random.Next(1, 49);
            int number_5 = random.Next(1, 49);
            int number_6 = random.Next(1, 49);
            
        }


        public virtual Game lotto { get; set; }

    }
}
