using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEAB.Models
{
    public class Warband
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        //leader
        public int LeaderId { get; set; }
        public virtual Hero Leader { get; set; }


        public Warband()
        {
            this.Units = new HashSet<Unit>();
        }

        public virtual ICollection<Unit> Units { get; set; }


        //utility stuff
        public string CreatorId { get; set; }
        public virtual ApplicationUser Creator { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }
}