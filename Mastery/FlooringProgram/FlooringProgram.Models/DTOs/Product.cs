using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models.DTOs
{
   public class Product
    {
       public string ProductType { get; set; }
       public decimal CostPerSqauareFoot { get; set; }
       public decimal LaborCostPerSquareFoot { get; set; }
    }
}
