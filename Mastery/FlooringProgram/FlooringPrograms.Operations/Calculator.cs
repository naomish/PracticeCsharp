using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;

namespace FlooringPrograms.Operations
{
  public  class Calculator
    {

      public void CalcuateValues(Order newOrder)
      {
          newOrder.MaterialCost = (newOrder.Area*newOrder.CostPerSquareFoot);
         
          newOrder.LaborCost = (newOrder.Area*newOrder.LaborCostPerSquareFoot);
         
          newOrder.Tax = (newOrder.TaxRate*newOrder.MaterialCost*.01M);

          newOrder.Total = (newOrder.MaterialCost + newOrder.LaborCost + newOrder.Tax);

      }
    }
}
