using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCappLabs.Web.Models.AppLabs
{
    public class PrimeSearchTool
    {
        [Required(ErrorMessage = "You gotta put in a number, no fractions or decimals.")]
       //[Range(0, 18446744073709551615, ErrorMessage = "Keep it between 18 quintillion and zero.")]
        [Range(0, 4294967290, ErrorMessage = "Make your number greater than 0 but less than 4,294,967,290")]
            public uint? FirstNumber { get; set; }
        public uint? NextPrime { get; set; } 
    }
}