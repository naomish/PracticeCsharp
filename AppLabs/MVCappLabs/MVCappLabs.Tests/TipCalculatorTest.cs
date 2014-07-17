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
    class TipCalculatorTest
    {

        [Test]
        public void CalculateTipTest()
        {
            var calculator = new TipCalculator();
            var request = new TipCalculationRequest {MealCost = 100, TipPercent = .2M};
            var result = calculator.CalculateTip(request);

            Assert.AreEqual(result.TipAmount, 20M);
            Assert.AreEqual(result.TotalCost, 120M);
        }
    }
}
