using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MVCappLabs.Models.Level1;

namespace MVCappLabs.BLL.Level1
{
  public  class TipCalculator
    {
      public TipCalculationResponse CalculateTip(TipCalculationRequest request)
      {
          var response = new TipCalculationResponse();
          response.TipPercent = request.TipPercent;
          response.MealCost = request.MealCost;
          response.TipAmount = response.TipPercent*response.MealCost;
          response.TotalCost = response.MealCost + response.TipAmount;

          response.TipAmount = Math.Round(response.TipAmount, 2); //limits response to two decimal places for currency
          response.TotalCost = Math.Round(response.TotalCost, 2);
          return response;
      }
    }
}
