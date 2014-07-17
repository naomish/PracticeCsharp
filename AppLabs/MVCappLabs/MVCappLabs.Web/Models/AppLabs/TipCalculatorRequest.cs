using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCappLabs.Web.Models.AppLabs
{
    public class TipCalculatorRequest
    {
        [Required(ErrorMessage = "Enter the meal amount")]
        public decimal? MealCost { get; set; }

        [Required(ErrorMessage = "Enter the tip amount")]
        [Range(0, 100)]
        public decimal? TipPercent { get; set; }
    }
}