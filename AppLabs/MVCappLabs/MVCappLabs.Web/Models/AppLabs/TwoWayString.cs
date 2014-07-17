using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCappLabs.Web.Models.AppLabs
{
    public class TwoWayString
    {
        [Required(ErrorMessage = "Enter a word or phrase")]
        public string Forward { get; set; }
        public string Reversed { get; set; }
    }
}