using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models.DTOs;
using NUnit.Framework;
using FlooringProgram.UI;


namespace FlooringPoject.Tests
{[TestFixture]
    class Tester
    {

    [Test]
    public void TestLoadFile()
    {
        string fake = "fake";

        var fm = new OrderRepository();

        List<Order> actual = fm.LoadOrdersFromFile(fake);
        Assert.IsTrue(actual !=null);
    }

    public void WriteToFile()
    {
        string fake = "fake";

        var saveInput = new List<Order>();
        var testOrder = new Order();
        testOrder.OrderNumber = 1;
        testOrder.Name = "Smith";
        testOrder.State = "OH";
        testOrder.TaxRate = .0235M;
        testOrder.ProductType = "Carpet";
        testOrder.Area = 2M;
        testOrder.LaborCostPerSquareFoot = 1.50M;
        testOrder.LaborCostPerSquareFoot = 3.25M;
        testOrder.MaterialCost = testOrder.Area * testOrder.CostPerSquareFoot;
        testOrder.LaborCost = testOrder.LaborCostPerSquareFoot*testOrder.Area;
        testOrder.Tax = testOrder.TaxRate*testOrder.MaterialCost;
        testOrder.Total = testOrder.MaterialCost + testOrder.LaborCost + testOrder.Tax;

        saveInput.Add(testOrder);
        var fm = new OrderRepository();
        fm.SaveOrdersToFile(saveInput, fake);


    }

    [Test]
    public void CaluclatorTest()
    {
        string taxFile = "Taxes";
        string productFile = "Products";
        string testFIle = "testFile";

        var saveInput = new List<Order>();
        var testOrder = new Order();

        var tax = new TaxRepository();
        var taxList = tax.LoadTaxesAndStatesFromFile();


    }

    [Test]
    public void TestOrderNumAssignment()
    {
        var testOrder = new Order();
        testOrder.Name = "Smith";
        testOrder.State = "OH";
        testOrder.TaxRate = 0.10M;
        testOrder.ProductType = "Carpet";
        testOrder.Area = 5M;
        testOrder.CostPerSquareFoot = 2M;
        testOrder.LaborCostPerSquareFoot = 1M;
        testOrder.MaterialCost = 4M;
        testOrder.LaborCost = 10M;
        testOrder.Tax = 10M;
        testOrder.Total = 10M;

        AddOrder p = new AddOrder();
        var list = p.GetTodaysOrders();
        int n = p.GetNextOrderNumber(list);
        Assert.IsTrue(n == 1);

    }

    }
}
