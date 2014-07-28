using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models;
using FlooringProgram.Models.DTOs;
using FlooringPrograms.Operations;

namespace FlooringPrograms.Operations
{
    public class AddOrderWorkFlow
    {
        public string _filename = "Orders_" + DateTime.Today.ToString("MMddyyy") + ".txt";

        public void Execute()
        {
            var order = GetUserOrderData();
            bool isGoodOrder = ConfirmOrderSubmission();
            if (isGoodOrder)
            {
                var orders = GetTodaysOrders();
                order.OrderNumber = GetNextOrderNumber(orders);
                AddNewOrder(order);
            }

        }

        private void AddNewOrder(Order order)
        {
            var todaysOrders = GetTodaysOrders();
            todaysOrders.Add(order);
            var r = new OrderRepository();
            r.SaveOrdersToFile(todaysOrders, _filename);
            Console.WriteLine("Your order has been saved!");
        }

        private Order GetUserOrderData()
        {
            Order newOrder = new Order();
            Calculator calculator = new Calculator();

            GetOrderName(newOrder);

            GetOrderArea(newOrder);

            GetStateAndTax(newOrder);

            GetProductAndCostAndLaborPerSqFt(newOrder);

            calculator.CalcuateValues(newOrder);

            DisplayOrderSummary(newOrder);

            return newOrder;


        }

        private void GetOrderArea(Order newOrder) //seems more complex than it needs to be. have someone check your try/catch bool interplay.
        {
            string userInput;
            bool isNumber = false;
            bool isReasonableQuantity = false;
            do
            {
                Console.Write("How many square feet do you want to cover?: ");
                userInput = Console.ReadLine();
                try
                {
                    newOrder.Area = decimal.Parse(userInput);
                    isNumber = true;
                    string quantConfirmation;
                    if (newOrder.Area > 2000)
                    {
                        do
                        {
                            Console.WriteLine("You asked for {0} square feet, are you sure you want that much (Y/N)?", userInput);
                            quantConfirmation = Console.ReadLine().ToUpper();
                            if (quantConfirmation == "Y")
                                isReasonableQuantity = true;

                        } while (!(quantConfirmation == "Y" || quantConfirmation == "N"));
                    }
                    else
                    {
                        isReasonableQuantity = true;
                    }

                }
                catch (Exception)
                {

                    Console.WriteLine("You entered {0}, please enter a NUMBER representing the area of flooring you require.", userInput);
                }


            } while (!isNumber || !isReasonableQuantity);
        }

        private void GetOrderName(Order newOrder)
        {
            do
            {
                Console.Write("Customer Name:");
                newOrder.Name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(newOrder.Name));

        }

        private void GetStateAndTax(Order newOrder)
        {
            var taxloader = new TaxRepository();
            List<Tax> taxList = taxloader.LoadTaxesAndStatesFromFile();
            int count = 0;
            bool isNotValidState = true;
            do
            {
                Console.Write("We operate in the following States:\n");
                foreach (var tax in taxList)
                {
                    Console.WriteLine("{0}", tax.State);
                }

                Console.WriteLine("\nWhich of these states are you in?: ");
                string userInput = Console.ReadLine().ToUpper();

                foreach (var taxSchedule in taxList)
                {

                    if (taxSchedule.State == userInput)
                    {
                        count++;
                        newOrder.State = userInput;
                        newOrder.TaxRate = taxSchedule.TaxRate;
                        isNotValidState = false;


                    }

                }

                if (count == 0)
                {
                    Console.WriteLine("You entered:{0}. That is not a valid state! Make sure you abbreviate, i.e.'OH' ", userInput);
                }

            } while (isNotValidState);

        }



        private void GetProductAndCostAndLaborPerSqFt(Order newOrder)
        {
            var productLoader = new ProductRespository();
            List<Product> productList = productLoader.LoadProductsFromFile();
            int count = 0;

            bool isNotValidProduct = true;//changing to product
            do
            {
                Console.WriteLine("\nThese are the products we carry:");

                foreach (var p in productList)
                {
                    Console.WriteLine("{0}", p.ProductType);
                }
                Console.Write("Enter what kind of floor you want: ");
                string userInput = Console.ReadLine();

                foreach (var product in productList)
                {

                    if (product.ProductType.ToUpper() == userInput.ToUpper())
                    {
                        count++;
                        newOrder.ProductType = product.ProductType;
                        newOrder.CostPerSquareFoot = product.CostPerSqauareFoot;
                        newOrder.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;
                        isNotValidProduct = false;

                    }

                }

                if (count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("We don't carry {0}. Please enter what kind of floor you want: ", userInput);
                }

            } while (isNotValidProduct);

        }

        private bool ConfirmOrderSubmission()
        {
            string userConfirmation;
            do
            {
                Console.Write("\nDo you wish to submit this order (Y/N)? :");
                userConfirmation = Console.ReadLine().ToUpper();


            } while (!(userConfirmation == "Y" || userConfirmation == "N"));

            if (userConfirmation == "N")
            {
                return false;
                
            }
            return true;
        }


        private void DisplayOrderSummary(Order newOrder)
        {
            Console.WriteLine("\nName: {0}", newOrder.Name);
            Console.WriteLine("State: {0}", newOrder.State);
            Console.WriteLine("Material: {0}", newOrder.ProductType);
            Console.WriteLine("Cost per square foot of {1}: {0:c}", newOrder.CostPerSquareFoot, newOrder.ProductType);
            Console.WriteLine("Size of room: {0}", newOrder.Area);
            Console.WriteLine("Installation cost per square foot of {1}: {0:C}", newOrder.LaborCostPerSquareFoot, newOrder.ProductType);
            Console.WriteLine("Total Cost of Materials: {0:c}", newOrder.MaterialCost);
            Console.WriteLine("Total cost of Installation: {0:C}", newOrder.LaborCost);
            Console.WriteLine("Tax: {0:C}", newOrder.Tax);
            Console.WriteLine("TOTAL COST: {0:C}", newOrder.Total);
        }

        public List<Order> GetTodaysOrders()
        {

            var p = new OrderRepository();
            return p.LoadOrdersFromFile(_filename);
        }

        public int GetNextOrderNumber(List<Order> orders)//don't know what happened to original code you wrote for this.
        {
            if (orders.Any())
                return orders.Max(o => o.OrderNumber) + 1;

            return 1;
        }

    }
}

//private string GetConfirmation()
//{

//    string userInput;

//    do
//    {
//        Console.WriteLine("Do you wish to confirm this order (Y/N)? ");
//        userInput = Console.ReadLine();
//        try
//        {
//            userInput = Console.ReadLine().ToUpper();

//        }
//        catch (Exception)
//        {

//            Console.WriteLine("You must enter a Y to confirm order or N to decline.");
//        }

//    } while (!(userInput == "Y" || userInput == "N"));


//    return userInput;


//}
