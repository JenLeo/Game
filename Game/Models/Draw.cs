using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models
{
    public class draw
    {
        public DateTime date_dt;

        [Key]
        [Display(Name = "Draw ID")]
        public String DrawID { get; set; }
      
        [Display(Name = "Draw Name")]
        public String DrawName { get; set; }
 
        [Display(Name = "When")]
        public DateTime draw_dt { get; set; }

        //public draw(String drawId, String drawName, DateTime _Datetime)
        //{
        //    this.DrawID = drawId;
        //    this.DrawName = drawName;
        //    this.draw_dt = _Datetime;

        //}

        //public draw()
        //{
        //}

        public static IEnumerable<draw> OrderByDescending(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public static object OrderBy(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public virtual ICollection<draw> Draw { get; set; }

    }
}

