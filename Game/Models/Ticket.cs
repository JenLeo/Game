using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Ticket
    {
        [Key]
        public string Ticket_id { get; set; }


        [Display(Name = "Draw")]
        [Required(ErrorMessage = "Please choose draw to play")]
        public String Draw { get; set; }
        public static String[] DrawTypes
        {
            get
            {
                return new String[] { "EuroDraw", "MillionPlus", "DailyJackpot" };
            }
        }



        [Required(ErrorMessage = "Please choose a number")]
        public int Number1 { get; set; }

        [Required(ErrorMessage = "Please choose a number")]
        public int Number2 { get; set; }

        [Required(ErrorMessage = "Please choose a number")]
        public int Number3 { get; set; }

        [Required(ErrorMessage = "Please choose a number")]
        public int Number4 { get; set; }

        [DisplayName("Price (€):")]
        public double Price { get; set; }

        public DateTime purchased { get; set; }

        public class BuyTicket : Ticket
        {
            public int Qty { get; set; }
        }


        public virtual ICollection<Game> lotto { get; set; }
    }
}
