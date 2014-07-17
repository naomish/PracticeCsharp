using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCappLabs.Web.Models.AppLabs
{
    public class FloorInputs 
    {
        [Required(ErrorMessage = "Enter width of room")]
        public decimal? Width { get; set; }  //i forget what the "?" is for

                [Required(ErrorMessage = "Enter length of room")]
        public decimal? Length { get; set; }

                [Required(ErrorMessage = "Enter cost of material per square foot")]
                public decimal? CostPerUnit { get; set; }

                public decimal? Area { get; set; }
                public decimal? FlooringCost { get; set; }
                public decimal? LaborCost { get; set; }
                public decimal? TotalCostEstimate { get; set; }
    }
}