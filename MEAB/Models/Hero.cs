using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEAB.Models
{
public class Hero : Unit
   {
      public int Might { get; set; }
      public int Will { get; set; }
      public int Fate { get; set; }
      public string Notes { get; set; }
   }
}