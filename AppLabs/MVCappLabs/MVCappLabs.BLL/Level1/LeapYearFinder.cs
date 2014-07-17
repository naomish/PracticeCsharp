using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MVCappLabs.Models.Level1;

namespace MVCappLabs.BLL.Level1
{
  public  class LeapYearFinder
    {
      public LeapYears SearchForLeapYears(LeapYears ly)
      {
          for (int i = ly.StartYear; i <= ly.EndYear; i++)
          {
              if ((i%4 == 0 && i%100 != 0) || (i%400 == 0))
              {
                  ly.Years.Add(i);
              }
          }

          return ly;

      }
     
    }
}
