using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models.DTOs
{
   public class Change
    {
       public int SilverDollars { get; set; }
       public int Quarters { get; set; }
       public int Dimes { get; set; }
       public int Nickels { get; set; }
       public int Pennies { get; set; }

    }
}
