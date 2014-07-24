using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCappLabs.Models.Level2
{
   public class ChangeRequest
    {
       public VendingItem Item { get; set; }
       public int Payment { get; set; }
       public int ChangeOwed { get; set; }
    }
}
