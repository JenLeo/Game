using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Game.Models
{
    public class Games
    {

        // azure connection string;
        // Server=tcp:lottoead.database.windows.net,1433;Initial Catalog=Lotto;Persist Security Info=False;User ID=JenEAD;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
        [Required]
        public int DrawID { get; set; }
        public String TicketId { get; set; }

        private Random random;

        public Random WinningNumbers()
        {
            random = new Random();
            int[] array = new int[3];
            random = new Random();

            for (int i = 0; i < 6; i++)
            {
                int result = random.Next(0, 49);
                int modulo = result % array.Length;
                array[modulo]++;
            }
            for (int i = 0; i < array.Length; i++)
            {
                return random;
            }

        }
       
        public override string ToString()
        {
            return String.Format("DrawID: {0} -  Winning Numbers: {1}  ", DrawID, random );
        }

        public virtual Games lotto { get; set; }

    }
}
