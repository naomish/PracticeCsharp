using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models.DTOs;
using Microsoft.Win32;

namespace FlooringProgram.UI.WorkFlows
{
    internal class RemoveOrderWorkFlow
    {
        private FetchOrdersMatchingDate f = new FetchOrdersMatchingDate();
        private string _currentFile;
        private List<Order> _ordersToDisplay;

        public RemoveOrderWorkFlow()
        {
            _ordersToDisplay = f.Execute();
            _currentFile = f.CurrentFile;
        }


        public void Execute()
        {

            if (_ordersToDisplay == null)
                return;
            DisplayOrders();
         Order  orderToDelete= ChooseOrderRemove();
            if (orderToDelete.OrderNumber != 0)
            DeleteOrder(orderToDelete);
        }

        private void DisplayOrders()
        {
            foreach (var o in _ordersToDisplay)
            {
                Console.WriteLine("{0:D} {1} {2} {3:C}", o.OrderNumber, o.Name, o.ProductType, o.Total);
            }

           // Console.ReadLine();
        }

        private Order ChooseOrderRemove()
        {
            bool res;
            int userNum;
            Order emptyOrder = new Order(); //helps user break out of workflow

            do
            {
                Console.Write("\nChoose order# to remove or M to exit: ");
                string userChoice = Console.ReadLine();

                res = int.TryParse(userChoice, out userNum);
                if (userChoice == "M" || userChoice == "m")
                    return emptyOrder;
                if (!res ||!_ordersToDisplay.Exists(o => o.OrderNumber == userNum))
                    Console.WriteLine("\nInvalid choice!");

            } while (!res || !_ordersToDisplay.Exists(o => o.OrderNumber == userNum));
           
            var choice = _ordersToDisplay.FirstOrDefault(o => o.OrderNumber == userNum);
            return choice;
        }
    

        private void DeleteOrder(Order choice)
        {
            
            string userConfirm;
            do
            {
                Console.WriteLine("{0:D} {1} {2} {3:C}", choice.OrderNumber, choice.Name, choice.ProductType,
                    choice.Total);
                Console.WriteLine("Confirm deletion of order?(Y/N) ");
                userConfirm = Console.ReadLine();



            } while (!(userConfirm == "Y" || userConfirm == "N"));

            switch (userConfirm)
            {
                case "Y":
                    _ordersToDisplay.Remove(choice);
                    SaveUpdatedFile();
                    break;

                case "N":
                    break;

            }

        }

        private void SaveUpdatedFile()
    {
        var ord = new OrderRepository();
        ord.SaveOrdersToFile(_ordersToDisplay, _currentFile);
    }

    }
}


