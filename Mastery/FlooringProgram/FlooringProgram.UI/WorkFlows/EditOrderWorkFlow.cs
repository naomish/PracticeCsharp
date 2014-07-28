using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models.DTOs;
using FlooringPrograms.Operations;

namespace FlooringProgram.UI.WorkFlows
{
    internal class EditOrderWorkFlow
    {

         FetchOrdersMatchingDate f = new FetchOrdersMatchingDate();
        public string CurrentFile;
        public List<Order> OrdersToDisplay;

        public EditOrderWorkFlow() //constructor
        {
            OrdersToDisplay = f.Execute();
            CurrentFile = f.CurrentFile;
        }


        public void Execute()
        {
            if (OrdersToDisplay == null)
                return;
            DisplayOrders();
          var selectedOrder=  ChooseOrderToEdit();
            if(selectedOrder.OrderNumber !=0)
            UpdateOrderInformation(selectedOrder);
        }

        private void DisplayOrders()
        {
            foreach (var o in OrdersToDisplay)
            {
                Console.WriteLine("{0:D} {1} {2} {3:C}", o.OrderNumber, o.Name, o.ProductType, o.Total);
            }

          //  Console.ReadLine();
        }

        private Order ChooseOrderToEdit()
        {
            bool res;
            int userNum;
            var emptyOrder = new Order(); //helps user break out of workflow
            do
            {
                Console.WriteLine("\nChoose order# to edit or M to exit to Menu: ");
                string userChoice = Console.ReadLine().ToUpper();

                res = int.TryParse(userChoice, out userNum);
                if (userChoice == "M")
                    return emptyOrder;
                if (!res|| !OrdersToDisplay.Exists(o => o.OrderNumber == userNum))
                    Console.WriteLine("\nInvalid choice");

            } while (!res|| !OrdersToDisplay.Exists(o => o.OrderNumber == userNum));

            var choice = OrdersToDisplay.FirstOrDefault(o => o.OrderNumber == userNum);
            return choice;
        }

        public  void UpdateOrderInformation(Order selectedOrder)
        {
            Console.WriteLine(
                "To edit the order, enter a new value for each field or leave blank to keep the existing one...");
            Console.WriteLine();

            Console.Write("First Name ({0})", selectedOrder.Name);  //UpdateName method
            string userInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userInput))
                selectedOrder.Name = userInput;


            bool isValidState = false;       //  UpdateState method
            do
            {
            Console.Write("State ({0})", selectedOrder.State);
            userInput = Console.ReadLine().ToUpper();
            var taxLoader = new TaxRepository();
            List<Tax> taxList = taxLoader.LoadTaxesAndStatesFromFile();
            if (!string.IsNullOrEmpty(userInput)&&(taxList.Exists(t=>t.State==userInput)))
            {
                isValidState = true;
                selectedOrder.State = userInput;
                UpdateTaxRate(selectedOrder);
                UpdateCosts(selectedOrder);
            }
            else if (string.IsNullOrEmpty(userInput))
            {
                break;
            }
            else
            {
                Console.WriteLine("{0} is not a valid entry for State. We operate in:", userInput);
                foreach (var tax in taxList)
                {
                    Console.WriteLine("{0}", tax.State);
                }
            }
       
            } while (!isValidState);




            bool isValidProduct = false;  //update Product Method
            do
            {
                Console.Write("Product Type ({0})", selectedOrder.ProductType);
                userInput = Console.ReadLine();
                var productLoader = new ProductRespository();
                List<Product> productList = productLoader.LoadProductsFromFile();
                if (!string.IsNullOrEmpty(userInput) && (productList.Exists(p => p.ProductType.ToUpper() == userInput.ToUpper())))
                {
                    isValidProduct = true;
                    selectedOrder.ProductType = userInput;
                    UpdateProductInfo(selectedOrder);
                    UpdateCosts(selectedOrder);
                }
                else if (string.IsNullOrEmpty(userInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("{0} is not in our inventory. We carry the following products: ", userInput);
                    foreach (var product in productList)
                    {
                        Console.WriteLine("{0}",product.ProductType );
                    }
                }
                
            } while (!isValidProduct);
          

            Console.Write("Area - ({0}):", selectedOrder.Area); //updateArea method
            userInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userInput))
            {
                bool res;
                decimal userArea;
                do
                {
                   // Console.Write("Area: ({0})", selectedOrder.Area);
                   // userInput = Console.ReadLine();

                    res = decimal.TryParse(userInput, out userArea);
                    if (!res)
                    {
                        Console.WriteLine("Invalid choice");
                        Console.Write("Area - ({0}):", selectedOrder.Area);
                        userInput = Console.ReadLine();
                        res = decimal.TryParse(userInput, out userArea);
                    }

                } while (!res);
                selectedOrder.Area = userArea;
                UpdateCosts(selectedOrder);


            }
            ConfirmAndUpdateOrder(selectedOrder);

        }


        private  void UpdateProductInfo(Order selectedOrder)
        {
            var p = new ProductRespository();
            var prodList = p.LoadProductsFromFile();
            var prod = prodList.Find(y => y.ProductType.ToUpper() == selectedOrder.ProductType.ToUpper());
            selectedOrder.ProductType = prod.ProductType;

            selectedOrder.CostPerSquareFoot = prod.CostPerSqauareFoot;
            selectedOrder.LaborCostPerSquareFoot = prod.LaborCostPerSquareFoot;

            var c = new Calculator();
            c.CalcuateValues(selectedOrder);
        }

        private  void UpdateCosts(Order selectedOrder)
        {
            var c = new Calculator();
            c.CalcuateValues(selectedOrder);

        }

        private  void UpdateTaxRate(Order selectedOrder)
        {
            TaxRepository t = new TaxRepository();
            var taxList = t.LoadTaxesAndStatesFromFile();
            var res = taxList.Find(p => p.State == selectedOrder.State); //or where instead of find and extra line?
            selectedOrder.TaxRate = res.TaxRate;
            //Tax taxObj = res.First();
            //selectedOrder.TaxRate = taxObj.TaxRate;
     
        }


       


        private  void ConfirmAndUpdateOrder(Order selectedOrder)
        {
            Console.Clear();

            string userConfirm;

            do
            {
                Console.WriteLine("{0}. {1} wants {4} square feet of {2} at {5:C} per unit. \nTotal with installation is {3:c}\n", selectedOrder.OrderNumber, selectedOrder.Name, selectedOrder.ProductType, selectedOrder.Total, selectedOrder.Area, selectedOrder.CostPerSquareFoot);
                Console.WriteLine("Confirm update of order? (Y/N)");
                userConfirm = Console.ReadLine();

            } while (!(userConfirm == "Y" || userConfirm == "N"));

            switch (userConfirm)
            {
                case "Y":
                    SaveUpdatedFile();
                    break;

                case "N":
                    break;
            }
        }

        private void SaveUpdatedFile()
        {
            var ord = new OrderRepository();
            ord.SaveOrdersToFile(OrdersToDisplay, CurrentFile);
        }

    }
}
