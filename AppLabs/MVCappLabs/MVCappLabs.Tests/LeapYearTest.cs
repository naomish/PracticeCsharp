using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCappLabs.BLL.Level1;
using MVCappLabs.Models.Level1;
using NUnit.Framework;

namespace MVCappLabs.Tests
{
    [TestFixture]
    class LeapYearTest
    {
        [Test]
        public void FindLeapYears()
        {
            var ly = new LeapYears();
            ly.StartYear = 1899;
            ly.EndYear = 1908;

            var leapFinder = new LeapYearFinder();
           var leaps = leapFinder.SearchForLeapYears(ly);

            int[] exp = {1904, 1908};

            for (int i = 0; i < ly.Years.Count; i++)
            {
               Assert.AreEqual(exp[i], ly.Years[i]);
            }

            Assert.AreEqual(leaps.Years.Count, 2);
        }

    }
}
