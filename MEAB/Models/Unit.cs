using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEAB.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        

        public string Fight { get; set; }
        public int Strength { get; set; }



        //virtuals

        //collections
        public virtual ICollection<UnitType> UnitTypes { get; set; }

        //utility stuff
        public string CreatorId { get; set; }
        public virtual ApplicationUser Creator { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }
}