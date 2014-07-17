using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCappLabs.Models.Level2
{
   public class CharacterCounts
    {

        public int Vowels { get; set; }
        public List<char> VowelList { get; set; }
        public int Consonants { get; set; }
        public List<char> ConsonantList { get; set; }
        public int Punctuation { get; set; }
        public List<char> NonLetters { get; set; }
        public int Spaces { get; set; }
        public int Ys { get; set; }
        public int TotalCharacters { get; set; }

        public CharacterCounts()
        {
            NonLetters = new List<char>();
            VowelList = new List<char>();
            ConsonantList = new List<char>();

        }
    }
}
