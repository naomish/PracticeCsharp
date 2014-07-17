using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCappLabs.Web.Models.AppLabs
{
    public class CharacterCountTool
    {
        [Required(ErrorMessage = "Enter some characters to count!")]
        public string TextInput { get; set; }

        public int Vowels { get; set; }
        public List<char> VowelList { get; set; }
        public int Consonants { get; set; }
        public List<char> ConsonantList { get; set; }
        public int Punctuation { get; set; }
        public List<char> NonLetters { get; set; }
        public int Spaces { get; set; }
        public int Ys { get; set; }
        public int TotalCharacters { get; set; }

        public CharacterCountTool()
        {
            NonLetters = new List<char>();
            VowelList = new List<char>();
            ConsonantList = new List<char>();

        }
    }
   
}