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
        public int Ticket_id { get; set; }

        [Required(ErrorMessage = "Please choose draw to play")]
        public string Draw { get; set; }

        [Required(ErrorMessage = "Please choose a number")]
        public int Number1 { get; set; }

        [Required(ErrorMessage = "Please choose a number")]
        public int Number2 { get; set; }

        [Required(ErrorMessage = "Please choose a number")]
        public int Number3 { get; set; }

        [Required(ErrorMessage = "Please choose a number")]
        public int Number4 { get; set; }
        public double Price { get; set; }

        public DateTime purchased { get; set; }


        public virtual ICollection<Game> lotto { get; set; }
    }
}
