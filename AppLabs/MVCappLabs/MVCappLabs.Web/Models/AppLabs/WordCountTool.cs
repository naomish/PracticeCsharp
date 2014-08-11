using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCappLabs.Web.Models.AppLabs
{
    public class WordCountTool
    {
        [Required(ErrorMessage = "Type words in this box.")]
        public string UserInput { get; set; }
        public int? Count { get; set; }
    }
}