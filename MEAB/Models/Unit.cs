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

        

      public int Fight { get; set; }
      public int Shoot { get; set; }
      public int Strength { get; set; }
      public int Defense { get; set; }
      public int Attacks { get; set; }
      public int Wounds { get; set; }
      public int Courage { get; set; }


      public int UnitTypeId { get; set; }
      //collections
      public virtual UnitType Type { get; set; }

      //utility stuff
      public string CreatorId { get; set; }
      public virtual ApplicationUser Creator { get; set; }

      public DateTimeOffset Created { get; set; }
      public DateTimeOffset? Updated { get; set; }
   }
}