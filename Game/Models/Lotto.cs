using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Game.Models
{
    public class Lotto
    {

        // azure connection string;
        // Server=tcp:lottoead.database.windows.net,1433;Initial Catalog=Lotto;Persist Security Info=False;User ID=JenEAD;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
        [Required]
        public int DrawID { get; set; }
        public int TicketId { get; set; }
        
        [Required]
        public double Price { get; set; }


        public virtual Lotto lotto { get; set; }

    }
}
