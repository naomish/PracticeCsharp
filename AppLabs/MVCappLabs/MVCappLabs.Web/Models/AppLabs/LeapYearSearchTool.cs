using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCappLabs.Web.Models.AppLabs
{
    public class LeapYearSearchTool
    {
        [Required (ErrorMessage ="Enter a starting year for your search range")]
        public int? StartYear { get; set; }

    [Required(ErrorMessage = "Enter an ending year for your search range")]
    public int? EndYear { get; set; }

         [Required(ErrorMessage = "Something's not right")]
    public List<int> Years { get; set; }

         public bool IsPostback { get; set; }

        public LeapYearSearchTool()
        {
             Years = new List<int>();
        }
         
        //public  LeapYearsCollection()   hmmmm is this not working because of validation attributes?
        //{
        //           List<int> Years = new List<int>();

        //}
      

    }
}