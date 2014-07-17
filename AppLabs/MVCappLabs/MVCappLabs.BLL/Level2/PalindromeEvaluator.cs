using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCappLabs.Models.Level2;

namespace MVCappLabs.BLL.Level2
{
   public class PalindromeEvaluator
    {
        public PalindromeRequest EvaluatePalindrome(PalindromeRequest pr )
        {
            pr.Candidate = StripRawString(pr.RawString);
            pr = CheckForPalindrome(pr);
            return pr;
        }

        private PalindromeRequest CheckForPalindrome(PalindromeRequest pr)
        {
            pr.ReverseCandidate = "";

            for (int i = pr.Candidate.Length - 1; i >= 0; i--)
            {
                pr.ReverseCandidate += pr.Candidate[i];
            }
            if (pr.ReverseCandidate == pr.Candidate)
            {
                pr.IsPalindrome = true;
            }
            return pr;
        }

        private string StripRawString(string rs)
        {        
          var  candidate = rs.ToLower().Replace(" ", "").Replace(".", "").Replace(",", "").Replace("'", "");
            return candidate;
        }
    }
}
