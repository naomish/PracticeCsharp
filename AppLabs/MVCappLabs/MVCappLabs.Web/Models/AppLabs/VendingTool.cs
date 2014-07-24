using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVCappLabs.Models.Level2;

namespace MVCappLabs.Web.Models.AppLabs
{
    public class VendingTool
    {
        public List<VendingItem> Items { get; set; }
        public VendingItem Item { get; set; }
        [Required(ErrorMessage = "Enter a number, no commas, spaces, or dollar sign.")]
        public decimal? Payment { get; set; }

      
    }
}