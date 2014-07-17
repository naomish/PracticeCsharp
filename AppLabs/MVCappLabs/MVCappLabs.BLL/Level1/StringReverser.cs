using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCappLabs.Models.Level1;

namespace MVCappLabs.BLL.Level1
{
   public class StringReverser
    {
       public StringBothWays ReverseString(StringBothWays text)
       {
           for (int i = text.Original.Length - 1; i >= 0; i--)
           {
               text.Backwards += text.Original[i];
           }

           return text;
       }
    }
}
