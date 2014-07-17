using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCappLabs.Models.Level2
{
   public class PalindromeRequest
    {
        public string RawString { get; set; }
        public string Candidate { get; set; }
        public string ReverseCandidate { get; set; }
        public bool IsPalindrome { get; set; }
    }
}
