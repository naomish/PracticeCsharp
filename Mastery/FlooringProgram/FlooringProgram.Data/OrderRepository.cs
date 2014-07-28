using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;

namespace FlooringProgram.Data
{

 public   class OrderRepository
 {
     public List<Order> LoadOrdersFromFile(string fileName)
     {
         if (File.Exists(fileName))
         {
             string[] allLines = File.ReadAllLines(fileName);

             return OrderListFromArray(allLines);
         }

         return new List<Order>();//we need to return a list with one item filled in
    
     }

     private List<Order> OrderListFromArray(string[] allLines)
     {
         var orders = new List<Order>();
         foreach (string line  in allLines.Skip(1))
         {
             string[] columns = line.Split('|');

             Order order = new Order();
             order.OrderNumber = int.Parse(columns[0]);
             order.Name = columns[1];
             order.State = columns[2];
             order.TaxRate = decimal.Parse(columns[3]);
             order.ProductType = columns[4];
             order.Area = decimal.Parse(columns[5]);
             order.CostPerSquareFoot = decimal.Parse(columns[6]);
             order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
             order.MaterialCost = decimal.Parse(columns[8]);
             order.LaborCost = decimal.Parse(columns[9]);
             order.Tax = decimal.Parse(columns[10]);
             order.Total = decimal.Parse(columns[11]);

             orders.Add(order);
         }

         return orders;
     }

     public void SaveOrdersToFile(List<Order> allOrders, string fileName)
     {
         if (File.Exists(fileName))
             File.Delete(fileName);
         const string header =
             "OrderNumber|CustomerName|State|TaxRate|ProductType|Area|CostPerSquareFoot|MaterialCost|LaborCost|Tax|Total";
         using (var writer = File.AppendText(fileName))
         {
             writer.WriteLine(header);

             foreach (var order in allOrders)
             {
                 string pipeSVLine = ConvertOrderToPipeSV(order);
                 writer.WriteLine(pipeSVLine);
             }
         }
     }

     private string ConvertOrderToPipeSV(Order order)
     {
         return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}", order.OrderNumber, order.Name,
             order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot,
             order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
     }
    
     



 }
}
