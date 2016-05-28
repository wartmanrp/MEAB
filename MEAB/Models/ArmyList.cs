using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEAB.Models
{
    public class ArmyList
    {
        public int Id { get; set; }
        public string ArmyName { get; set; }
        public int PointsLimit { get; set; }

        public int LeaderId { get; set; }
        public virtual Hero Leader { get; set; }

        //constructors
        public ArmyList()
        {
            this.Warbands = new HashSet<Warband>();
            this.Units = new HashSet<Unit>();
        }

        //collections for constructor
        public virtual ICollection<Warband> Warbands { get; set; }
        public virtual ICollection<Unit> Units { get; set; }

        //utility stuff
        public string CreatorId { get; set; }
        public virtual ApplicationUser Creator { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }
}