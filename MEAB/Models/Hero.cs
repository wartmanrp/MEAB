using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEAB.Models
{
    public class Hero
    {




        //utility stuff
        public string CreatorId { get; set; }
        public virtual ApplicationUser Creator { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }
}