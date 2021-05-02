using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Draw
    {
            
        [Key]
        public int DrawID { get; set; }
        [Required]
        [Display(Name = "Draw")]
        public string DrawName { get; set; }
        [Required]
        [Display(Name = "Taking Place")]
        public DateTime draw_dt { get; set; }

        public virtual ICollection<Games> lotto { get; set; }

    }
}

