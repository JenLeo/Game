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
        [Display(Name = "Draw ID")]
        public String DrawID { get; set; }
      
        [Display(Name = "Draw Name")]
        public String DrawName { get; set; }
 
        [Display(Name = "When")]
        public DateTime draw_dt { get; set; }

        public class Tckts : Draw
        {
            public int Qty { get; set; }
        }
        public virtual ICollection<Draw> draw { get; set; }

    }
}

