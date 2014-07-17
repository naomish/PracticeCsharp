using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCappLabs.Models.Level2;

namespace MVCappLabs.BLL.Level2
{
   public class PrimeFinder
    {
       public Primer FindPrime(Primer p)
       {
           bool isPrime = false;
           uint primeCandidate = p.StartNumber;

           do
           {
               primeCandidate += 1;

               if (primeCandidate % 2 != 0)
               {
                   uint primeDetector = 0;

                   for (uint i = 3; i <= Math.Sqrt(primeCandidate); i += 2)
                   {
                       if (primeCandidate % i == 0)
                       {
                           primeDetector++;
                       }
                   }

                   if (primeDetector == 0)
                       isPrime = true;

               }

           } while (isPrime == false);
           p.PrimeNumber = primeCandidate;
           return p;
       }
    }
}
