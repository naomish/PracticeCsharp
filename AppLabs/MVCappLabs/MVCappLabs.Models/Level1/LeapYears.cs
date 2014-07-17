using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCappLabs.Models.Level1
{
  public  class LeapYears
    {
      public List<int> Years { get; set; }
      public int StartYear { get; set; }
      public int EndYear { get; set; }

      public LeapYears()
      {
          Years = new List<int>();
      }
    }
}
