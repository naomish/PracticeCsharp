using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCappLabs.BLL.Level1;
using MVCappLabs.Models.Level1;
using NUnit.Framework;

namespace MVCappLabs.Tests
{[TestFixture]
    class FloorCalculatorTests
    {
    [Test]
    public void CalculateFlooring()
    {
        var calculator = new FlooringCalculator();
        var calculation = new FloorCalculation{Length = 10, Width = 10, CostPerUnit = 2};
        var result = calculator.CalculateFloor(calculation);

        Assert.AreEqual(result.Area, 100);
        Assert.AreEqual(result.FlooringCost, 200);
        Assert.AreEqual(result.TotalCostEstimate,630 );
    }
    }
}
