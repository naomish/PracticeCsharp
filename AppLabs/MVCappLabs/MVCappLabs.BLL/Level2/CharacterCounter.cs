using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MVCappLabs.Models.Level2;

namespace MVCappLabs.BLL.Level1
{
   public class CharacterCounter
    {
       public CharacterCounts CountCharacters(String textInput)
       {
           var counts = new CharacterCounts();
          var text = textInput.ToLower();
           foreach (var c in text)
           {
               if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
               {
                   counts.Vowels++;
                   counts.VowelList.Add(c);
               }

               else if (Char.IsWhiteSpace(c))
               {
                   counts.Spaces++;
               }

               else if (c == 'y')
               {
                   counts.Ys++;
               }

               else if (c == 'b' || c == 'd' || c == 'c' || c == 'f' || c == 'g' || c == 'h' || c == 'j' || c == 'k' ||
                  c == 'l' || c == 'm' || c == 'n' || c == 'p' || c == 'q' || c == 'r' || c == 's' || c == 't' ||
                  c == 'v' || c == 'w' || c == 'x' || c == 'z')
               {
                   counts.Consonants++;
                   counts.ConsonantList.Add(c);
               }

               else
               {
                   counts.Punctuation++;
                   counts.NonLetters.Add(c);
               }
           }
           counts.TotalCharacters = counts.Consonants + counts.Vowels + counts.Ys+ counts.Punctuation + counts.Spaces;
           return counts;
       }
    }
}
