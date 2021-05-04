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
        //ticket prices
        const double EDCost = 3.00;
        const double DJCost = 5.00;
        const double MPCost = 8.00;

        [Key]
        public string Ticket_id { get; set; }


        [Display(Name = "Draw")]
        [Required(ErrorMessage = "Please choose draw to play")]
        
        public static String[] DrawTypes
        {
            get
            {
                return new String[] { "EuroDraw", "MillionPlus", "DailyJackpot" };
            }
        }
        [Required]
        [Display(Name = "Draw Type")]
        public String DrawType { get; set; }


        [DisplayName("Number 1:")]
        [Range(1, 49, ErrorMessage = "Please choose a number between 1 and 49")]
        [Required(ErrorMessage = "Please choose a number")]
        public int Number1 { get; set; }

        [DisplayName("Number 2:")]
        [Range(1, 49, ErrorMessage = "Please choose a number between 1 and 49")]
        [Required(ErrorMessage = "Please choose a number between 1 and 49")]
        public int Number2 { get; set; }

        [DisplayName("Number 3:")]
        [Range(1, 49, ErrorMessage = "Please choose a number between 1 and 49")]
        [Required(ErrorMessage = "Please choose a number between 1 and 49")]
        public int Number3 { get; set; }

        [DisplayName("Number 4:")]
        [Range(1, 49, ErrorMessage = "Please choose a number between 1 and 49")]
        [Required(ErrorMessage = "Please choose a number between 1 and 49")]
        public int Number4 { get; set; }

        [DisplayName("Number 5:")]
        [Range(1, 49, ErrorMessage = "Please choose a number between 1 and 49")]
        [Required(ErrorMessage = "Please choose a number between 1 and 49")]
        public int Number5 { get; set; }

        [DisplayName("Number 6:")]
        [Range(1, 49, ErrorMessage = "Please choose a number between 1 and 49")]
        [Required(ErrorMessage = "Please choose a number between 1 and 49")]
        public int Number6 { get; set; }

        [DisplayName("Price (€):")]
        public double Price
        {
            get                             // checkprice
            {
                double cost = 0;
                if (DrawType == "EuroDraw")
                {
                    cost = EDCost;
                }
                else if (DrawType == "MillionPlus")
                {
                    cost = MPCost;
                }
                else if (DrawType == "DailyJackpot")
                {
                    cost = DJCost;
                }
                
                return cost;
            }
        }
        public DateTime purchased { get; set; }

        public class BuyTicket : Ticket
        {
            public int Qty { get; set; }
        }


        public virtual ICollection<Games> lotto { get; set; }
    }
}
