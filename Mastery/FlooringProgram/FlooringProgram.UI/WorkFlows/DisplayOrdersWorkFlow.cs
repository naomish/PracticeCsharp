using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models.DTOs;

namespace FlooringProgram.UI.WorkFlows
{
    public class DisplayOrdersWorkFlow
    {

        private List<Order> _ordersToDisplay;

        public void Execute()
        {
            GetOrderData();

        }



        private void GetOrderData()
        {
            var f = new FetchOrdersMatchingDate();
            _ordersToDisplay = f.Execute();
            if (_ordersToDisplay == null)
                return;
            DisplayOrders();
        }

        private void DisplayOrders()
        {
            foreach (var p in _ordersToDisplay)
            {
                Console.WriteLine("{0:D} {1} {2} {3:C}", p.OrderNumber, p.Name, p.ProductType, p.Total);
            }
            Console.ReadLine();

        }


    }
}
