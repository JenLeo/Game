using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Game.Models
{
    public class Games
    {

        [Key]
        public String GameId { get; set; }
        
        [Required]
        public int DrawID { get; set; }
        public String TicketId { get; set; }

        private Random random;

        public Random GamePlayed()

        {
            int[] array = new int[6];
            random = new Random();

            for (int i = 0; i < 6; i++)
            {
                int result = random.Next(0, 49);
                int modulo = result % array.Length;
                array[modulo]++;
            }
#pragma warning disable CS0162 // Unreachable code detected
            for (int i = 0; i < array.Length; i++)
#pragma warning restore CS0162 // Unreachable code detected
            {
                return random;
            }
            return random;
        }
        


        public virtual Games lotto { get; set; }
    }
}

    