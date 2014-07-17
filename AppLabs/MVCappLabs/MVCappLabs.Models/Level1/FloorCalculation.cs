using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCappLabs.Models.Level1
{
  public class FloorCalculation
    {
        public decimal Area { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal CostPerUnit { get; set; }
        public decimal FlooringCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal TotalCostEstimate { get; set; }
    }
}
