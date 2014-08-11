using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCappLabs.Models.Level3;

namespace MVCappLabs.BLL.Level3
{
  public  class WordEnumerator
    {
      public int CountWords(WordCount wc)
      {
          int count;
          var wordList = new List<string>();
          wordList = wc.Input.Split().ToList();
          count = wordList.Count();
          return count;
      }
    }
}
