using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCappLabs.Models.Level1
{
   public class TipCalculationResponse
   {
       public decimal TipPercent { get; set; }
       public decimal MealCost { get; set; }
       public decimal TipAmount { get; set; }
       public decimal TotalCost { get; set; }
    }
}
