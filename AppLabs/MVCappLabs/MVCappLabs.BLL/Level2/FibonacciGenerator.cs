using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCappLabs.BLL.Level2
{
  public  class FibonacciGenerator
    {
      public List<ulong> FindFibs(int n)
      {
          ulong first = 0;
          ulong second = 1;
          ulong nextFib;
          var fibList = new List<ulong>();
          if (n > 1)
          {fibList.Add(0);
              for (int i = 1; i < n; i++)
              {
                  nextFib = first + second;
                  fibList.Add(nextFib);
                  first = second;
                  second = nextFib;
              }
          }
          else
          {
              fibList.Add(0);
          }
          return fibList;
      }
    }
}
