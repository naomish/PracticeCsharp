using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCappLabs.Models.Level1;

namespace MVCappLabs.BLL.Level1
{
   public class FlooringCalculator
    {
       public FloorCalculation CalculateFloor(FloorCalculation fc)
       {
           fc.Area = fc.Width*fc.Length;
           fc.FlooringCost = fc.Area*fc.CostPerUnit;
           fc.LaborCost = Math.Ceiling(fc.Area / 5) * 21.50M;
           fc.TotalCostEstimate = fc.LaborCost + fc.FlooringCost;

           return fc;
       }
    }
}
