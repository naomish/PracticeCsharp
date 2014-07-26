using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler4_3digitProductPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {Program p = new Program();
            
            Console.WriteLine(p.LargestPalindromicProduct());
            Console.ReadLine();
        }

        public int LargestPalindromicProduct()
        {
            int int1 = 999;
            int int2 = 999;
            int biggestPal = 0;
            var biggestPals = new List<int>();

            while (biggestPal == 0 || int1>=100)
            {
                while (int1 >= 100)
                {
                    
                    for (int i = 999; i > 99; i--)
                    {

                        int testPal = (int1*int2);
                        string reversed = "";
                        for (int j = testPal.ToString().Length - 1; j >= 0; j--)
                        {
                            reversed += testPal.ToString()[j];
                        }

                        if (reversed == testPal.ToString())
                        {
                            biggestPal = testPal;
                            biggestPals.Add(biggestPal);
                            int2--;
                        }

                        else
                        {
                            int2--;
                        }

                    }
                    int2 = 999;
                    int1--;
                }
                            
               
            }
            int result = biggestPals.Max();
            return result;
           
        }
    }
}
