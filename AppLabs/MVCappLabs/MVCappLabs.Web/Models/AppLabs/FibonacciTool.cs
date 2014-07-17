using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCappLabs.Web.Views.AppLabs
{
    public class FibonacciTool
    {
        [Required(ErrorMessage = "Enter a number, and make it greater than 0")]
        [Range(1,93, ErrorMessage = "Make your number greater than 0 but less than 94")]
        public int? NumberOfFibs { get; set; }

        
        public List<ulong> FibonacciList { get; set; }

        public FibonacciTool()
        {
            FibonacciList = new List<ulong>();
        }
    }
} 